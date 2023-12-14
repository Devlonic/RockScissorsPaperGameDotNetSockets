using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using static System.Windows.Forms.AxHost;
using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace rsp.client.ui {
    public partial class Form1 : Form, IPlayerUi {
        Controller? controller;

        public event PlayerSelectFigureEventHandler? FigureSelected;
        public event UserAuthenticateEventHandler? UserAuthenticate;

        public Form1() {
            InitializeComponent();
            Reset();
        }

        void Reset() {
            this.controller?.Dispose();
            this.controller = new Controller(this);
            this.figureSelector.DataSource = Enum.GetValues(typeof(Figure));
        }

        public void PlayersListChanged(object sender, List<string> list) {
            this.Invoke(new(() => {
                playersLb.DataSource = list;
                playersLbInGame.DataSource = list;
            }));
        }

        private void Form1_Load_1(object sender, EventArgs e) {
            // just dummy for generating random nicks
            this.nicknameTb.Text = new string(( from s in "qwertyuiopasdfghjklzxcvbnm"
                                     where new Random().Next(10) < 5
                                     select s).ToArray());

            // to hide tab navigation header

            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;
        }

        private void figureSelector_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void figureSelector_MouseDoubleClick(object sender, MouseEventArgs e) {
            if(figureSelector.SelectedValue != null) {
                this.selectedFigure.Text = figureSelector.SelectedValue.ToString();
                this.FigureSelected?.Invoke(this, (Figure)figureSelector.SelectedValue);

            }
        }

        
        public void SetStatus(string state, Color color) {
            this.Invoke(new(() => {
                this.stateLabel.ForeColor = color;
                this.stateLabel.Text = state;
            }));
        }

        private void authbtn_Click(object sender, EventArgs e) {
            UserAuthenticate?.Invoke(this, nicknameTb.Text);
        }

        public void SetApplicationPart(ApplicationParts part) {
            this.Invoke(new(() => {
                switch ( part ) {
                    case ApplicationParts.Auth:
                    this.tabControl1.SelectTab(pageAuth);
                    break;
                    case ApplicationParts.Lobby:
                    this.tabControl1.SelectTab(pageLobby);
                    break;
                    case ApplicationParts.Game:
                    this.tabControl1.SelectTab(pageGame);
                    break;
                    case ApplicationParts.Results:
                    this.tabControl1.SelectTab(pageResults);
                    break;
                    case ApplicationParts.Lose:
                    this.tabControl1.SelectTab(pageLose);
                    break;
                    default:
                    break;
                }
            }));
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
        }

        public void HandleCriticalError(GameError? error) {
            MessageBox.Show($"Game error\n\n{error}","RSP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Reset();
            SetApplicationPart(ApplicationParts.Auth);
        }

        public void HandleGameEnd(GameResults? results) {
            SetApplicationPart(ApplicationParts.Results);

            gameResultLb.DataSource = results.Results;
            winnersLb.DataSource = results.WinPlayers;
            gameendtypeLabel.Text = results.ResultType.ToString();
            winnerLabel.Text = results?.Winner?.Nick ?? "#none#";
        }

        public void HandleNetworkError(NetworkError? error) {
            SetApplicationPart(ApplicationParts.Auth);
            MessageBox.Show($"Network error\n\n{error}", "RSP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Reset();
        }


        CancellationTokenSource timerCancelTokenSource;
        public void StartDisplayTimer(TimeSpan time) {
            timerCancelTokenSource = new CancellationTokenSource();

            int substract = 100;
            var timerTask = Task.Run(async () => {
                do {
                    time = time.Subtract(TimeSpan.FromMilliseconds(substract));
                    this.Invoke(new(() => {
                        timerDisplayLabel.Text = time.TotalMilliseconds.ToString();
                    }));
                    await Task.Delay(substract);
                } while ( time != TimeSpan.Zero && !timerCancelTokenSource.IsCancellationRequested );
            });
        }

        public void StopDisplayTimer() {
            timerCancelTokenSource.Cancel();
        }

        public void HandleGameFinish() {
            SetApplicationPart(ApplicationParts.Auth);
        }


        public void BlockSelectionPossibility() {
            this.Invoke(new(() => {
                this.figureSelector.Enabled = false;
            }));
        }

        public void UnblockSelectionPossibility() {
            this.Invoke(new(() => {
                this.figureSelector.Enabled = true;
            }));
        }

        public void HandleGameLose() {
            SetApplicationPart(ApplicationParts.Lose);
        }

        private void gotoAuthBtn_Click(object sender, EventArgs e) {
            SetApplicationPart(ApplicationParts.Auth);
        }
    }
}