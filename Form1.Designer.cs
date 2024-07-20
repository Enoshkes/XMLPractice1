namespace Windows
{
    partial class Form1
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
            BooksGridView = new DataGridView();
            AddButton = new Button();
            YearTextBox = new TextBox();
            AuthorTextBox = new TextBox();
            TitleTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)BooksGridView).BeginInit();
            SuspendLayout();
            // 
            // BooksGridView
            // 
            BooksGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            BooksGridView.Location = new Point(27, 25);
            BooksGridView.Name = "BooksGridView";
            BooksGridView.RowHeadersWidth = 51;
            BooksGridView.Size = new Size(300, 188);
            BooksGridView.TabIndex = 0;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(27, 301);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(94, 29);
            AddButton.TabIndex = 1;
            AddButton.Text = "Add Book";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButtonClickHandler;
            // 
            // YearTextBox
            // 
            YearTextBox.Location = new Point(157, 303);
            YearTextBox.Name = "YearTextBox";
            YearTextBox.PlaceholderText = "Year";
            YearTextBox.Size = new Size(125, 27);
            YearTextBox.TabIndex = 2;
            YearTextBox.KeyPress += YearTextBoxKeyHandler;
            // 
            // AuthorTextBox
            // 
            AuthorTextBox.Location = new Point(332, 301);
            AuthorTextBox.Name = "AuthorTextBox";
            AuthorTextBox.PlaceholderText = "Author";
            AuthorTextBox.Size = new Size(125, 27);
            AuthorTextBox.TabIndex = 3;
            // 
            // TitleTextBox
            // 
            TitleTextBox.Location = new Point(508, 301);
            TitleTextBox.Name = "TitleTextBox";
            TitleTextBox.PlaceholderText = "Title";
            TitleTextBox.Size = new Size(125, 27);
            TitleTextBox.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TitleTextBox);
            Controls.Add(AuthorTextBox);
            Controls.Add(YearTextBox);
            Controls.Add(AddButton);
            Controls.Add(BooksGridView);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)BooksGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView BooksGridView;
        private Button AddButton;
        private TextBox YearTextBox;
        private TextBox AuthorTextBox;
        private TextBox TitleTextBox;
    }
}
