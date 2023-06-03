namespace UAEnrollment
{
    partial class Additional_Violation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Additional_Violation));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges4 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.data_Violation = new System.Windows.Forms.DataGridView();
            this.txtViolation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btn_Add = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btn_Update = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btn_Delete = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btn_Cancel = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.data_Violation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // data_Violation
            // 
            this.data_Violation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_Violation.Location = new System.Drawing.Point(309, 101);
            this.data_Violation.Name = "data_Violation";
            this.data_Violation.Size = new System.Drawing.Size(606, 468);
            this.data_Violation.TabIndex = 0;
            this.data_Violation.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.data_Violation_CellMouseClick);
            // 
            // txtViolation
            // 
            this.txtViolation.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold);
            this.txtViolation.Location = new System.Drawing.Point(39, 134);
            this.txtViolation.Name = "txtViolation";
            this.txtViolation.Size = new System.Drawing.Size(235, 29);
            this.txtViolation.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(36, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 22);
            this.label1.TabIndex = 25;
            this.label1.Text = "Violation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(36, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 22);
            this.label2.TabIndex = 27;
            this.label2.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold);
            this.txtDescription.Location = new System.Drawing.Point(39, 208);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(235, 146);
            this.txtDescription.TabIndex = 26;
            // 
            // btn_Add
            // 
            this.btn_Add.AllowAnimations = true;
            this.btn_Add.AllowMouseEffects = true;
            this.btn_Add.AllowToggling = false;
            this.btn_Add.AnimationSpeed = 200;
            this.btn_Add.AutoGenerateColors = false;
            this.btn_Add.AutoRoundBorders = false;
            this.btn_Add.AutoSizeLeftIcon = true;
            this.btn_Add.AutoSizeRightIcon = true;
            this.btn_Add.BackColor = System.Drawing.Color.Transparent;
            this.btn_Add.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.btn_Add.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Add.BackgroundImage")));
            this.btn_Add.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_Add.ButtonText = "Add";
            this.btn_Add.ButtonTextMarginLeft = 0;
            this.btn_Add.ColorContrastOnClick = 45;
            this.btn_Add.ColorContrastOnHover = 45;
            this.btn_Add.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btn_Add.CustomizableEdges = borderEdges1;
            this.btn_Add.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_Add.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btn_Add.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_Add.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btn_Add.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btn_Add.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Add.ForeColor = System.Drawing.Color.White;
            this.btn_Add.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Add.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btn_Add.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btn_Add.IconMarginLeft = 11;
            this.btn_Add.IconPadding = 10;
            this.btn_Add.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Add.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btn_Add.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btn_Add.IconSize = 25;
            this.btn_Add.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.btn_Add.IdleBorderRadius = 1;
            this.btn_Add.IdleBorderThickness = 1;
            this.btn_Add.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.btn_Add.IdleIconLeftImage = null;
            this.btn_Add.IdleIconRightImage = null;
            this.btn_Add.IndicateFocus = false;
            this.btn_Add.Location = new System.Drawing.Point(173, 393);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btn_Add.OnDisabledState.BorderRadius = 1;
            this.btn_Add.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_Add.OnDisabledState.BorderThickness = 1;
            this.btn_Add.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_Add.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btn_Add.OnDisabledState.IconLeftImage = null;
            this.btn_Add.OnDisabledState.IconRightImage = null;
            this.btn_Add.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btn_Add.onHoverState.BorderRadius = 1;
            this.btn_Add.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_Add.onHoverState.BorderThickness = 1;
            this.btn_Add.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btn_Add.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btn_Add.onHoverState.IconLeftImage = null;
            this.btn_Add.onHoverState.IconRightImage = null;
            this.btn_Add.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btn_Add.OnIdleState.BorderRadius = 1;
            this.btn_Add.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_Add.OnIdleState.BorderThickness = 1;
            this.btn_Add.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btn_Add.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btn_Add.OnIdleState.IconLeftImage = null;
            this.btn_Add.OnIdleState.IconRightImage = null;
            this.btn_Add.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btn_Add.OnPressedState.BorderRadius = 1;
            this.btn_Add.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_Add.OnPressedState.BorderThickness = 1;
            this.btn_Add.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btn_Add.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btn_Add.OnPressedState.IconLeftImage = null;
            this.btn_Add.OnPressedState.IconRightImage = null;
            this.btn_Add.Size = new System.Drawing.Size(101, 39);
            this.btn_Add.TabIndex = 64;
            this.btn_Add.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Add.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_Add.TextMarginLeft = 0;
            this.btn_Add.TextPadding = new System.Windows.Forms.Padding(0);
            this.btn_Add.UseDefaultRadiusAndThickness = true;
            this.btn_Add.Click += new System.EventHandler(this.bunifuButton1_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.AllowAnimations = true;
            this.btn_Update.AllowMouseEffects = true;
            this.btn_Update.AllowToggling = false;
            this.btn_Update.AnimationSpeed = 200;
            this.btn_Update.AutoGenerateColors = false;
            this.btn_Update.AutoRoundBorders = false;
            this.btn_Update.AutoSizeLeftIcon = true;
            this.btn_Update.AutoSizeRightIcon = true;
            this.btn_Update.BackColor = System.Drawing.Color.Transparent;
            this.btn_Update.BackColor1 = System.Drawing.Color.Lime;
            this.btn_Update.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Update.BackgroundImage")));
            this.btn_Update.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_Update.ButtonText = "Update";
            this.btn_Update.ButtonTextMarginLeft = 0;
            this.btn_Update.ColorContrastOnClick = 45;
            this.btn_Update.ColorContrastOnHover = 45;
            this.btn_Update.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btn_Update.CustomizableEdges = borderEdges2;
            this.btn_Update.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_Update.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btn_Update.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_Update.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btn_Update.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btn_Update.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Update.ForeColor = System.Drawing.Color.White;
            this.btn_Update.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Update.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btn_Update.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btn_Update.IconMarginLeft = 11;
            this.btn_Update.IconPadding = 10;
            this.btn_Update.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Update.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btn_Update.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btn_Update.IconSize = 25;
            this.btn_Update.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.btn_Update.IdleBorderRadius = 1;
            this.btn_Update.IdleBorderThickness = 1;
            this.btn_Update.IdleFillColor = System.Drawing.Color.Lime;
            this.btn_Update.IdleIconLeftImage = null;
            this.btn_Update.IdleIconRightImage = null;
            this.btn_Update.IndicateFocus = false;
            this.btn_Update.Location = new System.Drawing.Point(40, 393);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btn_Update.OnDisabledState.BorderRadius = 1;
            this.btn_Update.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_Update.OnDisabledState.BorderThickness = 1;
            this.btn_Update.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_Update.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btn_Update.OnDisabledState.IconLeftImage = null;
            this.btn_Update.OnDisabledState.IconRightImage = null;
            this.btn_Update.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btn_Update.onHoverState.BorderRadius = 1;
            this.btn_Update.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_Update.onHoverState.BorderThickness = 1;
            this.btn_Update.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btn_Update.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btn_Update.onHoverState.IconLeftImage = null;
            this.btn_Update.onHoverState.IconRightImage = null;
            this.btn_Update.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btn_Update.OnIdleState.BorderRadius = 1;
            this.btn_Update.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_Update.OnIdleState.BorderThickness = 1;
            this.btn_Update.OnIdleState.FillColor = System.Drawing.Color.Lime;
            this.btn_Update.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btn_Update.OnIdleState.IconLeftImage = null;
            this.btn_Update.OnIdleState.IconRightImage = null;
            this.btn_Update.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btn_Update.OnPressedState.BorderRadius = 1;
            this.btn_Update.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_Update.OnPressedState.BorderThickness = 1;
            this.btn_Update.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btn_Update.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btn_Update.OnPressedState.IconLeftImage = null;
            this.btn_Update.OnPressedState.IconRightImage = null;
            this.btn_Update.Size = new System.Drawing.Size(101, 39);
            this.btn_Update.TabIndex = 65;
            this.btn_Update.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Update.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_Update.TextMarginLeft = 0;
            this.btn_Update.TextPadding = new System.Windows.Forms.Padding(0);
            this.btn_Update.UseDefaultRadiusAndThickness = true;
            this.btn_Update.Click += new System.EventHandler(this.bunifuButton2_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.AllowAnimations = true;
            this.btn_Delete.AllowMouseEffects = true;
            this.btn_Delete.AllowToggling = false;
            this.btn_Delete.AnimationSpeed = 200;
            this.btn_Delete.AutoGenerateColors = false;
            this.btn_Delete.AutoRoundBorders = false;
            this.btn_Delete.AutoSizeLeftIcon = true;
            this.btn_Delete.AutoSizeRightIcon = true;
            this.btn_Delete.BackColor = System.Drawing.Color.Transparent;
            this.btn_Delete.BackColor1 = System.Drawing.Color.Red;
            this.btn_Delete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Delete.BackgroundImage")));
            this.btn_Delete.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_Delete.ButtonText = "Delete";
            this.btn_Delete.ButtonTextMarginLeft = 0;
            this.btn_Delete.ColorContrastOnClick = 45;
            this.btn_Delete.ColorContrastOnHover = 45;
            this.btn_Delete.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges3.BottomLeft = true;
            borderEdges3.BottomRight = true;
            borderEdges3.TopLeft = true;
            borderEdges3.TopRight = true;
            this.btn_Delete.CustomizableEdges = borderEdges3;
            this.btn_Delete.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_Delete.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btn_Delete.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_Delete.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btn_Delete.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btn_Delete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Delete.ForeColor = System.Drawing.Color.White;
            this.btn_Delete.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Delete.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btn_Delete.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btn_Delete.IconMarginLeft = 11;
            this.btn_Delete.IconPadding = 10;
            this.btn_Delete.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Delete.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btn_Delete.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btn_Delete.IconSize = 25;
            this.btn_Delete.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.btn_Delete.IdleBorderRadius = 1;
            this.btn_Delete.IdleBorderThickness = 1;
            this.btn_Delete.IdleFillColor = System.Drawing.Color.Red;
            this.btn_Delete.IdleIconLeftImage = null;
            this.btn_Delete.IdleIconRightImage = null;
            this.btn_Delete.IndicateFocus = false;
            this.btn_Delete.Location = new System.Drawing.Point(40, 453);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btn_Delete.OnDisabledState.BorderRadius = 1;
            this.btn_Delete.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_Delete.OnDisabledState.BorderThickness = 1;
            this.btn_Delete.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_Delete.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btn_Delete.OnDisabledState.IconLeftImage = null;
            this.btn_Delete.OnDisabledState.IconRightImage = null;
            this.btn_Delete.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btn_Delete.onHoverState.BorderRadius = 1;
            this.btn_Delete.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_Delete.onHoverState.BorderThickness = 1;
            this.btn_Delete.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btn_Delete.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btn_Delete.onHoverState.IconLeftImage = null;
            this.btn_Delete.onHoverState.IconRightImage = null;
            this.btn_Delete.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btn_Delete.OnIdleState.BorderRadius = 1;
            this.btn_Delete.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_Delete.OnIdleState.BorderThickness = 1;
            this.btn_Delete.OnIdleState.FillColor = System.Drawing.Color.Red;
            this.btn_Delete.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btn_Delete.OnIdleState.IconLeftImage = null;
            this.btn_Delete.OnIdleState.IconRightImage = null;
            this.btn_Delete.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btn_Delete.OnPressedState.BorderRadius = 1;
            this.btn_Delete.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_Delete.OnPressedState.BorderThickness = 1;
            this.btn_Delete.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btn_Delete.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btn_Delete.OnPressedState.IconLeftImage = null;
            this.btn_Delete.OnPressedState.IconRightImage = null;
            this.btn_Delete.Size = new System.Drawing.Size(101, 39);
            this.btn_Delete.TabIndex = 66;
            this.btn_Delete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Delete.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_Delete.TextMarginLeft = 0;
            this.btn_Delete.TextPadding = new System.Windows.Forms.Padding(0);
            this.btn_Delete.UseDefaultRadiusAndThickness = true;
            this.btn_Delete.Click += new System.EventHandler(this.bunifuButton3_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.AllowAnimations = true;
            this.btn_Cancel.AllowMouseEffects = true;
            this.btn_Cancel.AllowToggling = false;
            this.btn_Cancel.AnimationSpeed = 200;
            this.btn_Cancel.AutoGenerateColors = false;
            this.btn_Cancel.AutoRoundBorders = false;
            this.btn_Cancel.AutoSizeLeftIcon = true;
            this.btn_Cancel.AutoSizeRightIcon = true;
            this.btn_Cancel.BackColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.BackColor1 = System.Drawing.Color.Yellow;
            this.btn_Cancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.BackgroundImage")));
            this.btn_Cancel.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_Cancel.ButtonText = "Cancel";
            this.btn_Cancel.ButtonTextMarginLeft = 0;
            this.btn_Cancel.ColorContrastOnClick = 45;
            this.btn_Cancel.ColorContrastOnHover = 45;
            this.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges4.BottomLeft = true;
            borderEdges4.BottomRight = true;
            borderEdges4.TopLeft = true;
            borderEdges4.TopRight = true;
            this.btn_Cancel.CustomizableEdges = borderEdges4;
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_Cancel.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btn_Cancel.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_Cancel.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btn_Cancel.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btn_Cancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Cancel.ForeColor = System.Drawing.Color.White;
            this.btn_Cancel.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Cancel.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btn_Cancel.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btn_Cancel.IconMarginLeft = 11;
            this.btn_Cancel.IconPadding = 10;
            this.btn_Cancel.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cancel.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btn_Cancel.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btn_Cancel.IconSize = 25;
            this.btn_Cancel.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.btn_Cancel.IdleBorderRadius = 1;
            this.btn_Cancel.IdleBorderThickness = 1;
            this.btn_Cancel.IdleFillColor = System.Drawing.Color.Yellow;
            this.btn_Cancel.IdleIconLeftImage = null;
            this.btn_Cancel.IdleIconRightImage = null;
            this.btn_Cancel.IndicateFocus = false;
            this.btn_Cancel.Location = new System.Drawing.Point(173, 453);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btn_Cancel.OnDisabledState.BorderRadius = 1;
            this.btn_Cancel.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_Cancel.OnDisabledState.BorderThickness = 1;
            this.btn_Cancel.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_Cancel.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btn_Cancel.OnDisabledState.IconLeftImage = null;
            this.btn_Cancel.OnDisabledState.IconRightImage = null;
            this.btn_Cancel.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btn_Cancel.onHoverState.BorderRadius = 1;
            this.btn_Cancel.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_Cancel.onHoverState.BorderThickness = 1;
            this.btn_Cancel.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btn_Cancel.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btn_Cancel.onHoverState.IconLeftImage = null;
            this.btn_Cancel.onHoverState.IconRightImage = null;
            this.btn_Cancel.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btn_Cancel.OnIdleState.BorderRadius = 1;
            this.btn_Cancel.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_Cancel.OnIdleState.BorderThickness = 1;
            this.btn_Cancel.OnIdleState.FillColor = System.Drawing.Color.Yellow;
            this.btn_Cancel.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btn_Cancel.OnIdleState.IconLeftImage = null;
            this.btn_Cancel.OnIdleState.IconRightImage = null;
            this.btn_Cancel.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btn_Cancel.OnPressedState.BorderRadius = 1;
            this.btn_Cancel.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_Cancel.OnPressedState.BorderThickness = 1;
            this.btn_Cancel.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btn_Cancel.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btn_Cancel.OnPressedState.IconLeftImage = null;
            this.btn_Cancel.OnPressedState.IconRightImage = null;
            this.btn_Cancel.Size = new System.Drawing.Size(101, 39);
            this.btn_Cancel.TabIndex = 67;
            this.btn_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Cancel.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_Cancel.TextMarginLeft = 0;
            this.btn_Cancel.TextPadding = new System.Windows.Forms.Padding(0);
            this.btn_Cancel.UseDefaultRadiusAndThickness = true;
            this.btn_Cancel.Click += new System.EventHandler(this.bunifuButton4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(391, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 50);
            this.label3.TabIndex = 68;
            this.label3.Text = "Violation";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtId
            // 
            this.txtId.AutoSize = true;
            this.txtId.BackColor = System.Drawing.SystemColors.Control;
            this.txtId.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold);
            this.txtId.ForeColor = System.Drawing.SystemColors.Control;
            this.txtId.Location = new System.Drawing.Point(36, 87);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(0, 22);
            this.txtId.TabIndex = 69;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(926, 583);
            this.pictureBox1.TabIndex = 70;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Additional_Violation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.IndianRed;
            this.ClientSize = new System.Drawing.Size(950, 607);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtViolation);
            this.Controls.Add(this.data_Violation);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Additional_Violation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Additional_Violation";
            this.Load += new System.EventHandler(this.Additional_Violation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data_Violation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView data_Violation;
        private System.Windows.Forms.TextBox txtViolation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescription;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btn_Add;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btn_Update;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btn_Delete;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btn_Cancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtId;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}