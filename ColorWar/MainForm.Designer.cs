using System.Drawing;
using System.Windows.Forms;

namespace ColorWar;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.Field = new System.Windows.Forms.PictureBox();
            this.ButtonFirstBlue = new System.Windows.Forms.PictureBox();
            this.ButtonFirstLime = new System.Windows.Forms.PictureBox();
            this.ButtonFirstCyan = new System.Windows.Forms.PictureBox();
            this.ButtonFirstRed = new System.Windows.Forms.PictureBox();
            this.ButtonFirstFuchsia = new System.Windows.Forms.PictureBox();
            this.ButtonSecondFuchsia = new System.Windows.Forms.PictureBox();
            this.ButtonSecondRed = new System.Windows.Forms.PictureBox();
            this.ButtonSecondCyan = new System.Windows.Forms.PictureBox();
            this.ButtonSecondLime = new System.Windows.Forms.PictureBox();
            this.ButtonSecondBlue = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Field)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonFirstBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonFirstLime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonFirstCyan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonFirstRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonFirstFuchsia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonSecondFuchsia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonSecondRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonSecondCyan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonSecondLime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonSecondBlue)).BeginInit();
            this.SuspendLayout();
            // 
            // Field
            // 
            this.Field.Location = new System.Drawing.Point(10, 10);
            this.Field.Margin = new System.Windows.Forms.Padding(10);
            this.Field.Name = "Field";
            this.Field.Size = new System.Drawing.Size(832, 560);
            this.Field.TabIndex = 0;
            this.Field.TabStop = false;
            // 
            // ButtonFirstBlue
            // 
            this.ButtonFirstBlue.CausesValidation = false;
            this.ButtonFirstBlue.Location = new System.Drawing.Point(10, 590);
            this.ButtonFirstBlue.Margin = new System.Windows.Forms.Padding(10);
            this.ButtonFirstBlue.Name = "ButtonFirstBlue";
            this.ButtonFirstBlue.Size = new System.Drawing.Size(40, 40);
            this.ButtonFirstBlue.TabIndex = 1;
            this.ButtonFirstBlue.TabStop = false;
            this.ButtonFirstBlue.Click += new System.EventHandler(this.Button_Click);
            // 
            // ButtonFirstLime
            // 
            this.ButtonFirstLime.Location = new System.Drawing.Point(70, 589);
            this.ButtonFirstLime.Margin = new System.Windows.Forms.Padding(10);
            this.ButtonFirstLime.Name = "ButtonFirstLime";
            this.ButtonFirstLime.Size = new System.Drawing.Size(40, 40);
            this.ButtonFirstLime.TabIndex = 2;
            this.ButtonFirstLime.TabStop = false;
            this.ButtonFirstLime.Click += new System.EventHandler(this.Button_Click);
            // 
            // ButtonFirstCyan
            // 
            this.ButtonFirstCyan.Location = new System.Drawing.Point(130, 589);
            this.ButtonFirstCyan.Margin = new System.Windows.Forms.Padding(10);
            this.ButtonFirstCyan.Name = "ButtonFirstCyan";
            this.ButtonFirstCyan.Size = new System.Drawing.Size(40, 40);
            this.ButtonFirstCyan.TabIndex = 3;
            this.ButtonFirstCyan.TabStop = false;
            this.ButtonFirstCyan.Click += new System.EventHandler(this.Button_Click);
            // 
            // ButtonFirstRed
            // 
            this.ButtonFirstRed.Location = new System.Drawing.Point(190, 589);
            this.ButtonFirstRed.Margin = new System.Windows.Forms.Padding(10);
            this.ButtonFirstRed.Name = "ButtonFirstRed";
            this.ButtonFirstRed.Size = new System.Drawing.Size(40, 40);
            this.ButtonFirstRed.TabIndex = 4;
            this.ButtonFirstRed.TabStop = false;
            this.ButtonFirstRed.Click += new System.EventHandler(this.Button_Click);
            // 
            // ButtonFirstFuchsia
            // 
            this.ButtonFirstFuchsia.Location = new System.Drawing.Point(250, 589);
            this.ButtonFirstFuchsia.Margin = new System.Windows.Forms.Padding(10);
            this.ButtonFirstFuchsia.Name = "ButtonFirstFuchsia";
            this.ButtonFirstFuchsia.Size = new System.Drawing.Size(40, 40);
            this.ButtonFirstFuchsia.TabIndex = 5;
            this.ButtonFirstFuchsia.TabStop = false;
            this.ButtonFirstFuchsia.Click += new System.EventHandler(this.Button_Click);
            // 
            // ButtonSecondFuchsia
            // 
            this.ButtonSecondFuchsia.Location = new System.Drawing.Point(802, 589);
            this.ButtonSecondFuchsia.Margin = new System.Windows.Forms.Padding(10);
            this.ButtonSecondFuchsia.Name = "ButtonSecondFuchsia";
            this.ButtonSecondFuchsia.Size = new System.Drawing.Size(40, 40);
            this.ButtonSecondFuchsia.TabIndex = 10;
            this.ButtonSecondFuchsia.TabStop = false;
            this.ButtonSecondFuchsia.Click += new System.EventHandler(this.Button_Click);
            // 
            // ButtonSecondRed
            // 
            this.ButtonSecondRed.Location = new System.Drawing.Point(742, 590);
            this.ButtonSecondRed.Margin = new System.Windows.Forms.Padding(10);
            this.ButtonSecondRed.Name = "ButtonSecondRed";
            this.ButtonSecondRed.Size = new System.Drawing.Size(40, 40);
            this.ButtonSecondRed.TabIndex = 9;
            this.ButtonSecondRed.TabStop = false;
            this.ButtonSecondRed.Click += new System.EventHandler(this.Button_Click);
            // 
            // ButtonSecondCyan
            // 
            this.ButtonSecondCyan.Location = new System.Drawing.Point(682, 590);
            this.ButtonSecondCyan.Margin = new System.Windows.Forms.Padding(10);
            this.ButtonSecondCyan.Name = "ButtonSecondCyan";
            this.ButtonSecondCyan.Size = new System.Drawing.Size(40, 40);
            this.ButtonSecondCyan.TabIndex = 8;
            this.ButtonSecondCyan.TabStop = false;
            this.ButtonSecondCyan.Click += new System.EventHandler(this.Button_Click);
            // 
            // ButtonSecondLime
            // 
            this.ButtonSecondLime.Location = new System.Drawing.Point(622, 590);
            this.ButtonSecondLime.Margin = new System.Windows.Forms.Padding(10);
            this.ButtonSecondLime.Name = "ButtonSecondLime";
            this.ButtonSecondLime.Size = new System.Drawing.Size(40, 40);
            this.ButtonSecondLime.TabIndex = 7;
            this.ButtonSecondLime.TabStop = false;
            this.ButtonSecondLime.Click += new System.EventHandler(this.Button_Click);
            // 
            // ButtonSecondBlue
            // 
            this.ButtonSecondBlue.Location = new System.Drawing.Point(562, 590);
            this.ButtonSecondBlue.Margin = new System.Windows.Forms.Padding(10);
            this.ButtonSecondBlue.Name = "ButtonSecondBlue";
            this.ButtonSecondBlue.Size = new System.Drawing.Size(40, 40);
            this.ButtonSecondBlue.TabIndex = 6;
            this.ButtonSecondBlue.TabStop = false;
            this.ButtonSecondBlue.Click += new System.EventHandler(this.Button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(891, 648);
            this.Controls.Add(this.ButtonSecondFuchsia);
            this.Controls.Add(this.ButtonSecondRed);
            this.Controls.Add(this.ButtonSecondCyan);
            this.Controls.Add(this.ButtonSecondLime);
            this.Controls.Add(this.ButtonSecondBlue);
            this.Controls.Add(this.ButtonFirstFuchsia);
            this.Controls.Add(this.ButtonFirstRed);
            this.Controls.Add(this.ButtonFirstCyan);
            this.Controls.Add(this.ButtonFirstLime);
            this.Controls.Add(this.ButtonFirstBlue);
            this.Controls.Add(this.Field);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "Война цветов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Field)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonFirstBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonFirstLime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonFirstCyan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonFirstRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonFirstFuchsia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonSecondFuchsia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonSecondRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonSecondCyan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonSecondLime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonSecondBlue)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private PictureBox Field;
    private PictureBox ButtonFirstBlue;
    private PictureBox ButtonFirstLime;
    private PictureBox ButtonFirstCyan;
    private PictureBox ButtonFirstRed;
    private PictureBox ButtonFirstFuchsia;
    private PictureBox ButtonSecondFuchsia;
    private PictureBox ButtonSecondRed;
    private PictureBox ButtonSecondCyan;
    private PictureBox ButtonSecondLime;
    private PictureBox ButtonSecondBlue;
}
