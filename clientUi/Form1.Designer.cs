namespace rsp.client.ui {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if ( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.selectedFigure = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stateLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pageAuth = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.authbtn = new System.Windows.Forms.Button();
            this.nicknameTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pageLobby = new System.Windows.Forms.TabPage();
            this.playersLb = new System.Windows.Forms.ListBox();
            this.pageGame = new System.Windows.Forms.TabPage();
            this.playersLbInGame = new System.Windows.Forms.ListBox();
            this.timerDisplayLabel = new System.Windows.Forms.Label();
            this.figureSelector = new System.Windows.Forms.ListBox();
            this.pageResults = new System.Windows.Forms.TabPage();
            this.gameendtypeLabel = new System.Windows.Forms.Label();
            this.winnersLb = new System.Windows.Forms.ListBox();
            this.gameResultLb = new System.Windows.Forms.ListBox();
            this.winnerLabel = new System.Windows.Forms.Label();
            this.pageLose = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.gotoAuthBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.pageAuth.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.pageLobby.SuspendLayout();
            this.pageGame.SuspendLayout();
            this.pageResults.SuspendLayout();
            this.pageLose.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectedFigure
            // 
            this.selectedFigure.AutoSize = true;
            this.selectedFigure.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.selectedFigure.Location = new System.Drawing.Point(12, 343);
            this.selectedFigure.Name = "selectedFigure";
            this.selectedFigure.Size = new System.Drawing.Size(0, 81);
            this.selectedFigure.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stateLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 579);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1065, 26);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // stateLabel
            // 
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(51, 20);
            this.stateLabel.Text = "{state}";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.pageAuth);
            this.tabControl1.Controls.Add(this.pageLobby);
            this.tabControl1.Controls.Add(this.pageGame);
            this.tabControl1.Controls.Add(this.pageResults);
            this.tabControl1.Controls.Add(this.pageLose);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(50, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1065, 579);
            this.tabControl1.TabIndex = 4;
            // 
            // pageAuth
            // 
            this.pageAuth.Controls.Add(this.tableLayoutPanel1);
            this.pageAuth.Location = new System.Drawing.Point(4, 34);
            this.pageAuth.Name = "pageAuth";
            this.pageAuth.Padding = new System.Windows.Forms.Padding(3);
            this.pageAuth.Size = new System.Drawing.Size(1057, 541);
            this.pageAuth.TabIndex = 0;
            this.pageAuth.Text = "Auth";
            this.pageAuth.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1051, 535);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.authbtn, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.nicknameTb, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(265, 136);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(519, 261);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // authbtn
            // 
            this.authbtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.authbtn.Location = new System.Drawing.Point(24, 198);
            this.authbtn.Margin = new System.Windows.Forms.Padding(24);
            this.authbtn.Name = "authbtn";
            this.authbtn.Size = new System.Drawing.Size(471, 39);
            this.authbtn.TabIndex = 0;
            this.authbtn.Text = "Auth";
            this.authbtn.UseVisualStyleBackColor = true;
            this.authbtn.Click += new System.EventHandler(this.authbtn_Click);
            // 
            // nicknameTb
            // 
            this.nicknameTb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nicknameTb.Location = new System.Drawing.Point(24, 111);
            this.nicknameTb.Margin = new System.Windows.Forms.Padding(24);
            this.nicknameTb.Name = "nicknameTb";
            this.nicknameTb.Size = new System.Drawing.Size(471, 27);
            this.nicknameTb.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter nickname";
            // 
            // pageLobby
            // 
            this.pageLobby.Controls.Add(this.playersLb);
            this.pageLobby.Location = new System.Drawing.Point(4, 34);
            this.pageLobby.Name = "pageLobby";
            this.pageLobby.Padding = new System.Windows.Forms.Padding(3);
            this.pageLobby.Size = new System.Drawing.Size(1057, 541);
            this.pageLobby.TabIndex = 1;
            this.pageLobby.Text = "Lobby";
            this.pageLobby.UseVisualStyleBackColor = true;
            // 
            // playersLb
            // 
            this.playersLb.Dock = System.Windows.Forms.DockStyle.Right;
            this.playersLb.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.playersLb.FormattingEnabled = true;
            this.playersLb.ItemHeight = 45;
            this.playersLb.Location = new System.Drawing.Point(746, 3);
            this.playersLb.Name = "playersLb";
            this.playersLb.Size = new System.Drawing.Size(308, 535);
            this.playersLb.TabIndex = 1;
            // 
            // pageGame
            // 
            this.pageGame.Controls.Add(this.playersLbInGame);
            this.pageGame.Controls.Add(this.timerDisplayLabel);
            this.pageGame.Controls.Add(this.figureSelector);
            this.pageGame.Location = new System.Drawing.Point(4, 34);
            this.pageGame.Name = "pageGame";
            this.pageGame.Padding = new System.Windows.Forms.Padding(3);
            this.pageGame.Size = new System.Drawing.Size(1057, 541);
            this.pageGame.TabIndex = 2;
            this.pageGame.Text = "Game";
            this.pageGame.UseVisualStyleBackColor = true;
            // 
            // playersLbInGame
            // 
            this.playersLbInGame.Dock = System.Windows.Forms.DockStyle.Right;
            this.playersLbInGame.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.playersLbInGame.FormattingEnabled = true;
            this.playersLbInGame.ItemHeight = 45;
            this.playersLbInGame.Location = new System.Drawing.Point(746, 3);
            this.playersLbInGame.Name = "playersLbInGame";
            this.playersLbInGame.Size = new System.Drawing.Size(308, 535);
            this.playersLbInGame.TabIndex = 4;
            // 
            // timerDisplayLabel
            // 
            this.timerDisplayLabel.AutoSize = true;
            this.timerDisplayLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.timerDisplayLabel.Location = new System.Drawing.Point(286, 3);
            this.timerDisplayLabel.Name = "timerDisplayLabel";
            this.timerDisplayLabel.Size = new System.Drawing.Size(45, 54);
            this.timerDisplayLabel.TabIndex = 3;
            this.timerDisplayLabel.Text = "0";
            // 
            // figureSelector
            // 
            this.figureSelector.Dock = System.Windows.Forms.DockStyle.Left;
            this.figureSelector.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.figureSelector.FormattingEnabled = true;
            this.figureSelector.ItemHeight = 81;
            this.figureSelector.Location = new System.Drawing.Point(3, 3);
            this.figureSelector.Name = "figureSelector";
            this.figureSelector.Size = new System.Drawing.Size(277, 535);
            this.figureSelector.TabIndex = 2;
            this.figureSelector.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.figureSelector_MouseDoubleClick);
            // 
            // pageResults
            // 
            this.pageResults.Controls.Add(this.gameendtypeLabel);
            this.pageResults.Controls.Add(this.winnersLb);
            this.pageResults.Controls.Add(this.gameResultLb);
            this.pageResults.Controls.Add(this.winnerLabel);
            this.pageResults.Location = new System.Drawing.Point(4, 34);
            this.pageResults.Name = "pageResults";
            this.pageResults.Padding = new System.Windows.Forms.Padding(3);
            this.pageResults.Size = new System.Drawing.Size(1057, 541);
            this.pageResults.TabIndex = 3;
            this.pageResults.Text = "Results";
            this.pageResults.UseVisualStyleBackColor = true;
            // 
            // gameendtypeLabel
            // 
            this.gameendtypeLabel.AutoSize = true;
            this.gameendtypeLabel.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gameendtypeLabel.Location = new System.Drawing.Point(8, 65);
            this.gameendtypeLabel.Name = "gameendtypeLabel";
            this.gameendtypeLabel.Size = new System.Drawing.Size(223, 45);
            this.gameendtypeLabel.TabIndex = 5;
            this.gameendtypeLabel.Text = "Game End: {0}";
            // 
            // winnersLb
            // 
            this.winnersLb.Dock = System.Windows.Forms.DockStyle.Right;
            this.winnersLb.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.winnersLb.FormattingEnabled = true;
            this.winnersLb.ItemHeight = 45;
            this.winnersLb.Location = new System.Drawing.Point(438, 3);
            this.winnersLb.Name = "winnersLb";
            this.winnersLb.Size = new System.Drawing.Size(308, 535);
            this.winnersLb.TabIndex = 3;
            // 
            // gameResultLb
            // 
            this.gameResultLb.Dock = System.Windows.Forms.DockStyle.Right;
            this.gameResultLb.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gameResultLb.FormattingEnabled = true;
            this.gameResultLb.ItemHeight = 45;
            this.gameResultLb.Location = new System.Drawing.Point(746, 3);
            this.gameResultLb.Name = "gameResultLb";
            this.gameResultLb.Size = new System.Drawing.Size(308, 535);
            this.gameResultLb.TabIndex = 2;
            // 
            // winnerLabel
            // 
            this.winnerLabel.AutoSize = true;
            this.winnerLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.winnerLabel.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.winnerLabel.Location = new System.Drawing.Point(3, 3);
            this.winnerLabel.Name = "winnerLabel";
            this.winnerLabel.Size = new System.Drawing.Size(276, 62);
            this.winnerLabel.TabIndex = 4;
            this.winnerLabel.Text = "Winner: {0}";
            // 
            // pageLose
            // 
            this.pageLose.Controls.Add(this.tableLayoutPanel3);
            this.pageLose.Location = new System.Drawing.Point(4, 34);
            this.pageLose.Name = "pageLose";
            this.pageLose.Padding = new System.Windows.Forms.Padding(3);
            this.pageLose.Size = new System.Drawing.Size(1057, 541);
            this.pageLose.TabIndex = 4;
            this.pageLose.Text = "Lose";
            this.pageLose.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Red;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1051, 535);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.gotoAuthBtn, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(265, 136);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(519, 261);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // gotoAuthBtn
            // 
            this.gotoAuthBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gotoAuthBtn.Location = new System.Drawing.Point(24, 198);
            this.gotoAuthBtn.Margin = new System.Windows.Forms.Padding(24);
            this.gotoAuthBtn.Name = "gotoAuthBtn";
            this.gotoAuthBtn.Size = new System.Drawing.Size(471, 39);
            this.gotoAuthBtn.TabIndex = 0;
            this.gotoAuthBtn.Text = "Go to auth";
            this.gotoAuthBtn.UseVisualStyleBackColor = true;
            this.gotoAuthBtn.Click += new System.EventHandler(this.gotoAuthBtn_Click);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(495, 63);
            this.label2.TabIndex = 2;
            this.label2.Text = "You lose!";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 605);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.selectedFigure);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.pageAuth.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.pageLobby.ResumeLayout(false);
            this.pageGame.ResumeLayout(false);
            this.pageGame.PerformLayout();
            this.pageResults.ResumeLayout(false);
            this.pageResults.PerformLayout();
            this.pageLose.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label selectedFigure;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel stateLabel;
        private TabControl tabControl1;
        private TabPage pageAuth;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button authbtn;
        private TextBox nicknameTb;
        private Label label1;
        private TabPage pageLobby;
        private ListBox playersLb;
        private TabPage pageGame;
        private ListBox figureSelector;
        private TabPage pageResults;
        private ListBox gameResultLb;
        private Label winnerLabel;
        private ListBox winnersLb;
        private Label gameendtypeLabel;
        private Label timerDisplayLabel;
        private TabPage pageLose;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private Button gotoAuthBtn;
        private Label label2;
        private ListBox playersLbInGame;
    }
}