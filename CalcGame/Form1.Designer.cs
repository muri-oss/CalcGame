namespace CalcGame
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.InvaderTbox = new System.Windows.Forms.TextBox();
            this.InvadeTimer = new System.Windows.Forms.Timer(this.components);
            this.targetTbox = new System.Windows.Forms.TextBox();
            this.targetBtn = new System.Windows.Forms.Button();
            this.startBtn = new System.Windows.Forms.Button();
            this.shootBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InvaderTbox
            // 
            this.InvaderTbox.BackColor = System.Drawing.SystemColors.Window;
            this.InvaderTbox.CausesValidation = false;
            this.InvaderTbox.Font = new System.Drawing.Font("Noto Mono", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvaderTbox.Location = new System.Drawing.Point(96, 77);
            this.InvaderTbox.Name = "InvaderTbox";
            this.InvaderTbox.ReadOnly = true;
            this.InvaderTbox.Size = new System.Drawing.Size(237, 46);
            this.InvaderTbox.TabIndex = 0;
            this.InvaderTbox.TabStop = false;
            this.InvaderTbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // InvadeTimer
            // 
            this.InvadeTimer.Interval = 1000;
            this.InvadeTimer.Tick += new System.EventHandler(this.InvadeTimer_Tick);
            // 
            // targetTbox
            // 
            this.targetTbox.BackColor = System.Drawing.SystemColors.Window;
            this.targetTbox.CausesValidation = false;
            this.targetTbox.Font = new System.Drawing.Font("Noto Mono", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetTbox.Location = new System.Drawing.Point(60, 77);
            this.targetTbox.MaxLength = 1;
            this.targetTbox.Name = "targetTbox";
            this.targetTbox.ReadOnly = true;
            this.targetTbox.Size = new System.Drawing.Size(30, 46);
            this.targetTbox.TabIndex = 1;
            this.targetTbox.TabStop = false;
            this.targetTbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // targetBtn
            // 
            this.targetBtn.Location = new System.Drawing.Point(60, 177);
            this.targetBtn.Name = "targetBtn";
            this.targetBtn.Size = new System.Drawing.Size(75, 23);
            this.targetBtn.TabIndex = 2;
            this.targetBtn.TabStop = false;
            this.targetBtn.Text = "Target";
            this.targetBtn.UseVisualStyleBackColor = true;
            this.targetBtn.Click += new System.EventHandler(this.targetBtn_Click);
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(154, 176);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 23);
            this.startBtn.TabIndex = 3;
            this.startBtn.TabStop = false;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // shootBtn
            // 
            this.shootBtn.Location = new System.Drawing.Point(254, 176);
            this.shootBtn.Name = "shootBtn";
            this.shootBtn.Size = new System.Drawing.Size(75, 23);
            this.shootBtn.TabIndex = 4;
            this.shootBtn.TabStop = false;
            this.shootBtn.Text = "Shoot";
            this.shootBtn.UseVisualStyleBackColor = true;
            this.shootBtn.Click += new System.EventHandler(this.shootBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.shootBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.targetBtn);
            this.Controls.Add(this.targetTbox);
            this.Controls.Add(this.InvaderTbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InvaderTbox;
        private System.Windows.Forms.Timer InvadeTimer;
        private System.Windows.Forms.TextBox targetTbox;
        private System.Windows.Forms.Button targetBtn;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button shootBtn;
    }
}

