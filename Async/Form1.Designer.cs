namespace Async
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_loadadd = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_apm = new System.Windows.Forms.Button();
            this.btn_Eap = new System.Windows.Forms.Button();
            this.rtb_State = new System.Windows.Forms.RichTextBox();
            this.rtb_State2 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txt_loadadd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_loadadd
            // 
            this.txt_loadadd.Location = new System.Drawing.Point(155, 12);
            this.txt_loadadd.Name = "txt_loadadd";
            this.txt_loadadd.Size = new System.Drawing.Size(294, 28);
            this.txt_loadadd.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "下载地址：";
            // 
            // btn_apm
            // 
            this.btn_apm.Location = new System.Drawing.Point(43, 71);
            this.btn_apm.Name = "btn_apm";
            this.btn_apm.Size = new System.Drawing.Size(125, 31);
            this.btn_apm.TabIndex = 2;
            this.btn_apm.Text = "下载APM";
            this.btn_apm.UseVisualStyleBackColor = true;
            this.btn_apm.Click += new System.EventHandler(this.btn_apm_Click);
            // 
            // btn_Eap
            // 
            this.btn_Eap.Location = new System.Drawing.Point(533, 61);
            this.btn_Eap.Name = "btn_Eap";
            this.btn_Eap.Size = new System.Drawing.Size(125, 31);
            this.btn_Eap.TabIndex = 2;
            this.btn_Eap.Text = "下载EAp";
            this.btn_Eap.UseVisualStyleBackColor = true;
            // 
            // rtb_State
            // 
            this.rtb_State.Location = new System.Drawing.Point(43, 118);
            this.rtb_State.Name = "rtb_State";
            this.rtb_State.Size = new System.Drawing.Size(365, 333);
            this.rtb_State.TabIndex = 3;
            this.rtb_State.Text = "";
            // 
            // rtb_State2
            // 
            this.rtb_State2.Location = new System.Drawing.Point(533, 118);
            this.rtb_State2.Name = "rtb_State2";
            this.rtb_State2.Size = new System.Drawing.Size(365, 333);
            this.rtb_State2.TabIndex = 3;
            this.rtb_State2.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 487);
            this.Controls.Add(this.rtb_State2);
            this.Controls.Add(this.rtb_State);
            this.Controls.Add(this.btn_Eap);
            this.Controls.Add(this.btn_apm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_loadadd);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.txt_loadadd.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txt_loadadd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_apm;
        private System.Windows.Forms.Button btn_Eap;
        private System.Windows.Forms.RichTextBox rtb_State;
        private System.Windows.Forms.RichTextBox rtb_State2;
    }
}

