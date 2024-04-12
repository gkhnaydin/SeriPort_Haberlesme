namespace SeriPort_Haberlesme
{
    partial class Form1
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
            this.lblPortSec = new System.Windows.Forms.Label();
            this.comboPortAdi = new System.Windows.Forms.ComboBox();
            this.btnYenile = new System.Windows.Forms.Button();
            this.comboBaudRate = new System.Windows.Forms.ComboBox();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.btnBaglan = new System.Windows.Forms.Button();
            this.listState = new System.Windows.Forms.ListView();
            this.label7 = new System.Windows.Forms.Label();
            this.lblAlinan = new System.Windows.Forms.Label();
            this.btnGonder = new System.Windows.Forms.Button();
            this.comboMessageType = new System.Windows.Forms.ComboBox();
            this.listAlinanData = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.teDeviceID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblPortSec
            // 
            this.lblPortSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPortSec.Location = new System.Drawing.Point(13, 19);
            this.lblPortSec.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPortSec.Name = "lblPortSec";
            this.lblPortSec.Size = new System.Drawing.Size(155, 24);
            this.lblPortSec.TabIndex = 2;
            this.lblPortSec.Text = "Port Seçiniz";
            // 
            // comboPortAdi
            // 
            this.comboPortAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboPortAdi.FormattingEnabled = true;
            this.comboPortAdi.Location = new System.Drawing.Point(176, 18);
            this.comboPortAdi.Margin = new System.Windows.Forms.Padding(4);
            this.comboPortAdi.Name = "comboPortAdi";
            this.comboPortAdi.Size = new System.Drawing.Size(66, 24);
            this.comboPortAdi.TabIndex = 10;
            // 
            // btnYenile
            // 
            this.btnYenile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYenile.Location = new System.Drawing.Point(249, 17);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(55, 24);
            this.btnYenile.TabIndex = 44;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.UseVisualStyleBackColor = true;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // comboBaudRate
            // 
            this.comboBaudRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBaudRate.FormattingEnabled = true;
            this.comboBaudRate.Location = new System.Drawing.Point(176, 55);
            this.comboBaudRate.Margin = new System.Windows.Forms.Padding(4);
            this.comboBaudRate.Name = "comboBaudRate";
            this.comboBaudRate.Size = new System.Drawing.Size(128, 24);
            this.comboBaudRate.TabIndex = 46;
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaudRate.Location = new System.Drawing.Point(13, 55);
            this.lblBaudRate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(155, 24);
            this.lblBaudRate.TabIndex = 45;
            this.lblBaudRate.Text = "Veri Hızı (Baud Rate)";
            // 
            // btnBaglan
            // 
            this.btnBaglan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaglan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBaglan.Location = new System.Drawing.Point(16, 97);
            this.btnBaglan.Margin = new System.Windows.Forms.Padding(4);
            this.btnBaglan.Name = "btnBaglan";
            this.btnBaglan.Size = new System.Drawing.Size(288, 31);
            this.btnBaglan.TabIndex = 47;
            this.btnBaglan.Text = "BAĞLAN";
            this.btnBaglan.UseVisualStyleBackColor = true;
            this.btnBaglan.Click += new System.EventHandler(this.btnBaglan_Click);
            // 
            // listState
            // 
            this.listState.HideSelection = false;
            this.listState.Location = new System.Drawing.Point(16, 135);
            this.listState.Name = "listState";
            this.listState.Size = new System.Drawing.Size(288, 326);
            this.listState.TabIndex = 48;
            this.listState.UseCompatibleStateImageBehavior = false;
            this.listState.View = System.Windows.Forms.View.List;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Highlight;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(323, 17);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(394, 24);
            this.label7.TabIndex = 49;
            this.label7.Text = "GÖNDERİLEN VERİ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAlinan
            // 
            this.lblAlinan.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblAlinan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAlinan.Location = new System.Drawing.Point(323, 211);
            this.lblAlinan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAlinan.Name = "lblAlinan";
            this.lblAlinan.Size = new System.Drawing.Size(394, 29);
            this.lblAlinan.TabIndex = 51;
            this.lblAlinan.Text = "ALINAN VERİ";
            this.lblAlinan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGonder
            // 
            this.btnGonder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGonder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGonder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGonder.Location = new System.Drawing.Point(323, 135);
            this.btnGonder.Margin = new System.Windows.Forms.Padding(4);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(394, 31);
            this.btnGonder.TabIndex = 53;
            this.btnGonder.Text = "GÖNDER";
            this.btnGonder.UseVisualStyleBackColor = true;
            this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
            // 
            // comboMessageType
            // 
            this.comboMessageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMessageType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboMessageType.FormattingEnabled = true;
            this.comboMessageType.Items.AddRange(new object[] {
            "Okutulan kart bilgisini verir.",
            "Ekrana kart okutunuz yazar.",
            "Ekrandan kart okutunuz siler.",
            "Okutulan kart bilgisini siler.",
            "Ekrandaki yazıyı siler.",
            "Ekrana metin gönder"});
            this.comboMessageType.Location = new System.Drawing.Point(323, 97);
            this.comboMessageType.Margin = new System.Windows.Forms.Padding(4);
            this.comboMessageType.Name = "comboMessageType";
            this.comboMessageType.Size = new System.Drawing.Size(394, 24);
            this.comboMessageType.TabIndex = 54;
            // 
            // listAlinanData
            // 
            this.listAlinanData.GridLines = true;
            this.listAlinanData.HideSelection = false;
            this.listAlinanData.Location = new System.Drawing.Point(323, 243);
            this.listAlinanData.Name = "listAlinanData";
            this.listAlinanData.Size = new System.Drawing.Size(394, 218);
            this.listAlinanData.TabIndex = 55;
            this.listAlinanData.UseCompatibleStateImageBehavior = false;
            this.listAlinanData.View = System.Windows.Forms.View.List;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(323, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 24);
            this.label1.TabIndex = 56;
            this.label1.Text = "Cihaz ID";
            // 
            // teDeviceID
            // 
            this.teDeviceID.Location = new System.Drawing.Point(408, 55);
            this.teDeviceID.Name = "teDeviceID";
            this.teDeviceID.Size = new System.Drawing.Size(100, 20);
            this.teDeviceID.TabIndex = 57;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 473);
            this.Controls.Add(this.teDeviceID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listAlinanData);
            this.Controls.Add(this.comboMessageType);
            this.Controls.Add(this.btnGonder);
            this.Controls.Add(this.lblAlinan);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listState);
            this.Controls.Add(this.btnBaglan);
            this.Controls.Add(this.comboBaudRate);
            this.Controls.Add(this.lblBaudRate);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.comboPortAdi);
            this.Controls.Add(this.lblPortSec);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPortSec;
        private System.Windows.Forms.ComboBox comboPortAdi;
        private System.Windows.Forms.Button btnYenile;
        private System.Windows.Forms.ComboBox comboBaudRate;
        private System.Windows.Forms.Label lblBaudRate;
        private System.Windows.Forms.Button btnBaglan;
        private System.Windows.Forms.ListView listState;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblAlinan;
        private System.Windows.Forms.Button btnGonder;
        private System.Windows.Forms.ComboBox comboMessageType;
        private System.Windows.Forms.ListView listAlinanData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox teDeviceID;
    }
}

