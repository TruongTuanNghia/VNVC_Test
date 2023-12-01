
namespace VNVC
{
    partial class frtUserBet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMoneyBet = new System.Windows.Forms.TextBox();
            this.btnBet = new System.Windows.Forms.Button();
            this.nrBet = new System.Windows.Forms.NumericUpDown();
            this.dtgUserBet = new System.Windows.Forms.DataGridView();
            this.DateBet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HourSlot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberBet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoneyBet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Results = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nrBet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUserBet)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Location = new System.Drawing.Point(262, 72);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(165, 13);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Bạn đang đặt cược cho tiếp theo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số tiền cược:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(164, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Chọn số đặt cược:";
            // 
            // txtMoneyBet
            // 
            this.txtMoneyBet.Location = new System.Drawing.Point(269, 141);
            this.txtMoneyBet.Name = "txtMoneyBet";
            this.txtMoneyBet.Size = new System.Drawing.Size(158, 20);
            this.txtMoneyBet.TabIndex = 4;
            this.txtMoneyBet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMoneyBet_KeyPress);
            // 
            // btnBet
            // 
            this.btnBet.Location = new System.Drawing.Point(305, 177);
            this.btnBet.Name = "btnBet";
            this.btnBet.Size = new System.Drawing.Size(75, 23);
            this.btnBet.TabIndex = 5;
            this.btnBet.Text = "Đặt cược";
            this.btnBet.UseVisualStyleBackColor = true;
            this.btnBet.Click += new System.EventHandler(this.btnBet_Click);
            // 
            // nrBet
            // 
            this.nrBet.Location = new System.Drawing.Point(294, 104);
            this.nrBet.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nrBet.Name = "nrBet";
            this.nrBet.ReadOnly = true;
            this.nrBet.Size = new System.Drawing.Size(97, 20);
            this.nrBet.TabIndex = 6;
            // 
            // dtgUserBet
            // 
            this.dtgUserBet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgUserBet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DateBet,
            this.HourSlot,
            this.NumberBet,
            this.MoneyBet,
            this.Results});
            this.dtgUserBet.Location = new System.Drawing.Point(60, 228);
            this.dtgUserBet.Name = "dtgUserBet";
            this.dtgUserBet.Size = new System.Drawing.Size(536, 150);
            this.dtgUserBet.TabIndex = 7;
            this.dtgUserBet.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dtgUserBet_RowPostPaint);
            // 
            // DateBet
            // 
            this.DateBet.DataPropertyName = "DateBet";
            this.DateBet.HeaderText = "Ngày Cược";
            this.DateBet.Name = "DateBet";
            this.DateBet.ReadOnly = true;
            this.DateBet.Width = 150;
            // 
            // HourSlot
            // 
            this.HourSlot.DataPropertyName = "HourSlot";
            this.HourSlot.HeaderText = "Slot";
            this.HourSlot.Name = "HourSlot";
            this.HourSlot.ReadOnly = true;
            this.HourSlot.Width = 30;
            // 
            // NumberBet
            // 
            this.NumberBet.DataPropertyName = "NumberBet";
            this.NumberBet.HeaderText = "Số Cược";
            this.NumberBet.Name = "NumberBet";
            this.NumberBet.ReadOnly = true;
            this.NumberBet.Width = 70;
            // 
            // MoneyBet
            // 
            this.MoneyBet.DataPropertyName = "MoneyBet";
            this.MoneyBet.HeaderText = "Tiền Cược";
            this.MoneyBet.Name = "MoneyBet";
            this.MoneyBet.ReadOnly = true;
            // 
            // Results
            // 
            this.Results.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Results.DataPropertyName = "Results";
            this.Results.HeaderText = "Kết quả";
            this.Results.Name = "Results";
            this.Results.ReadOnly = true;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbName.Location = new System.Drawing.Point(436, 24);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(36, 13);
            this.lbName.TabIndex = 8;
            this.lbName.Text = "Chào";
            // 
            // frtUserBet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 450);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.dtgUserBet);
            this.Controls.Add(this.nrBet);
            this.Controls.Add(this.btnBet);
            this.Controls.Add(this.txtMoneyBet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbTitle);
            this.Name = "frtUserBet";
            this.Text = "Đặt cược";
            this.Load += new System.EventHandler(this.frtUserBet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nrBet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUserBet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMoneyBet;
        private System.Windows.Forms.Button btnBet;
        private System.Windows.Forms.NumericUpDown nrBet;
        private System.Windows.Forms.DataGridView dtgUserBet;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateBet;
        private System.Windows.Forms.DataGridViewTextBoxColumn HourSlot;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberBet;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoneyBet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Results;
        private System.Windows.Forms.Label lbName;
    }
}