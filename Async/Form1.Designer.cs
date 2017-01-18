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
            this.rtb_State2 = new System.Windows.Forms.RichTextBox();
            this.btn_Pause = new System.Windows.Forms.Button();
            this.pgbar = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btn_downloadtap = new System.Windows.Forms.Button();
            this.btn_pausetap = new System.Windows.Forms.Button();
            this.btn_DownLoadAsync = new System.Windows.Forms.Button();
            this.btn_PauseAsync = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txt_loadadd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_loadadd
            // 
            this.txt_loadadd.Location = new System.Drawing.Point(155, 12);
            this.txt_loadadd.Name = "txt_loadadd";
            this.txt_loadadd.Size = new System.Drawing.Size(462, 28);
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
            this.btn_apm.Location = new System.Drawing.Point(37, 142);
            this.btn_apm.Name = "btn_apm";
            this.btn_apm.Size = new System.Drawing.Size(125, 31);
            this.btn_apm.TabIndex = 2;
            this.btn_apm.Text = "下载APM";
            this.btn_apm.UseVisualStyleBackColor = true;
            this.btn_apm.Click += new System.EventHandler(this.btn_apm_Click);
            // 
            // btn_Eap
            // 
            this.btn_Eap.Location = new System.Drawing.Point(37, 217);
            this.btn_Eap.Name = "btn_Eap";
            this.btn_Eap.Size = new System.Drawing.Size(125, 31);
            this.btn_Eap.TabIndex = 2;
            this.btn_Eap.Text = "下载EAP";
            this.btn_Eap.UseVisualStyleBackColor = true;
            this.btn_Eap.Click += new System.EventHandler(this.btn_Eap_Click);
            // 
            // rtb_State2
            // 
            this.rtb_State2.Location = new System.Drawing.Point(362, 110);
            this.rtb_State2.Name = "rtb_State2";
            this.rtb_State2.Size = new System.Drawing.Size(411, 346);
            this.rtb_State2.TabIndex = 3;
            this.rtb_State2.Text = "";
            // 
            // btn_Pause
            // 
            this.btn_Pause.Location = new System.Drawing.Point(198, 217);
            this.btn_Pause.Name = "btn_Pause";
            this.btn_Pause.Size = new System.Drawing.Size(125, 31);
            this.btn_Pause.TabIndex = 2;
            this.btn_Pause.Text = "暂停EAP";
            this.btn_Pause.UseVisualStyleBackColor = true;
            this.btn_Pause.Click += new System.EventHandler(this.btn_Pause_Click);
            // 
            // pgbar
            // 
            this.pgbar.Location = new System.Drawing.Point(37, 65);
            this.pgbar.Name = "pgbar";
            this.pgbar.Size = new System.Drawing.Size(580, 26);
            this.pgbar.TabIndex = 4;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // btn_downloadtap
            // 
            this.btn_downloadtap.Location = new System.Drawing.Point(37, 288);
            this.btn_downloadtap.Name = "btn_downloadtap";
            this.btn_downloadtap.Size = new System.Drawing.Size(125, 31);
            this.btn_downloadtap.TabIndex = 2;
            this.btn_downloadtap.Text = "下载TAP";
            this.btn_downloadtap.UseVisualStyleBackColor = true;
            this.btn_downloadtap.Click += new System.EventHandler(this.btn_downloadtap_Click);
            // 
            // btn_pausetap
            // 
            this.btn_pausetap.Location = new System.Drawing.Point(198, 288);
            this.btn_pausetap.Name = "btn_pausetap";
            this.btn_pausetap.Size = new System.Drawing.Size(125, 31);
            this.btn_pausetap.TabIndex = 2;
            this.btn_pausetap.Text = "暂停TAP";
            this.btn_pausetap.UseVisualStyleBackColor = true;
            this.btn_pausetap.Click += new System.EventHandler(this.btn_pausetap_Click);
            // 
            // btn_DownLoadAsync
            // 
            this.btn_DownLoadAsync.Location = new System.Drawing.Point(37, 361);
            this.btn_DownLoadAsync.Name = "btn_DownLoadAsync";
            this.btn_DownLoadAsync.Size = new System.Drawing.Size(125, 31);
            this.btn_DownLoadAsync.TabIndex = 2;
            this.btn_DownLoadAsync.Text = "下载Async";
            this.btn_DownLoadAsync.UseVisualStyleBackColor = true;
            this.btn_DownLoadAsync.Click += new System.EventHandler(this.btn_DownLoadAsync_Click);
            // 
            // btn_PauseAsync
            // 
            this.btn_PauseAsync.Location = new System.Drawing.Point(198, 361);
            this.btn_PauseAsync.Name = "btn_PauseAsync";
            this.btn_PauseAsync.Size = new System.Drawing.Size(125, 31);
            this.btn_PauseAsync.TabIndex = 2;
            this.btn_PauseAsync.Text = "暂停Async";
            this.btn_PauseAsync.UseVisualStyleBackColor = true;
            this.btn_PauseAsync.Click += new System.EventHandler(this.btn_PauseAsync_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 487);
            this.Controls.Add(this.pgbar);
            this.Controls.Add(this.rtb_State2);
            this.Controls.Add(this.btn_Pause);
            this.Controls.Add(this.btn_pausetap);
            this.Controls.Add(this.btn_PauseAsync);
            this.Controls.Add(this.btn_DownLoadAsync);
            this.Controls.Add(this.btn_downloadtap);
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
        private System.Windows.Forms.RichTextBox rtb_State2;
        private System.Windows.Forms.Button btn_Pause;
        private System.Windows.Forms.ProgressBar pgbar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btn_downloadtap;
        private System.Windows.Forms.Button btn_pausetap;
        private System.Windows.Forms.Button btn_DownLoadAsync;
        private System.Windows.Forms.Button btn_PauseAsync;
    }
}

