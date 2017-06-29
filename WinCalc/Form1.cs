using ReactCalc;
using ReactCalc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinCalc
{
    public partial class frmMain : Form
    {
        private Calc Calc { get; set; }

        private IOperation operation { get; set; }

        private IOperation Operation
        {
            get
            {
                return operation;
            }
            set
            {
                operation = value;
                DispOperation = value as IDisplayOperation;
            }
        }

        private IDisplayOperation DispOperation { get; set; }

        private DateTime? LastPressTime { get; set; }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Calc = new Calc();

            var operations = Calc.Operations;

            lbOperation.DataSource = operations;
            lbOperation.DisplayMember = "Name";

            lbOperation.SelectedIndex = 0;

            lblResult.Text = "";
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            tbX.Focus();
            //ставим свойство всем контролам кроме текстбоксов, чтобы при нажатии на ТАБ не переходил фокус на них
            btnClose.TabStop = false;
            lbOperation.TabStop = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Calculate(object sender)
        {
            //определяем операцию

            if (Operation == null)
            {
                lblResult.Text = "Выберите нормальную операцию";
                return;
            }
            //определяем входные данные
            var x = Calc.toDouble(tbX.Text);
            var y = Calc.toDouble(tbY.Text);

            try
            {
                //вычисляем
                var result = Calc.Execute(Operation.Name, new[] { x, y });
                //возвращаем результат
                lblResult.Text = string.Format(" = {0}{1}", result, Environment.NewLine);
            }
            catch (Exception ex)
            {
                lblResult.Text = string.Format("Опаньки: {0}", ex.Message);
            }
        }

        private void lbOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDescription.Text = "";
            Operation = lbOperation.SelectedItem as IOperation;

            //если операция новая, то добавляем автора и описание
            if (DispOperation != null)
            {
                lblDescription.Text = string.Format("Автор: {0}{1}Описание: {2}",
                    DispOperation.Author,
                    Environment.NewLine,
                    !string.IsNullOrWhiteSpace(DispOperation.Description) ? DispOperation.Description : "Нет описания"
                    );
            }
            //если старая операция, то автора ставим дефолтного и в описании пишем "нет описания"
            else
                lblDescription.Text = string.Format("Автор: facebook inc.{0}Описание: Нет описания", Environment.NewLine);

            //обнуляем результат предыдущего вычисления
            lblResult.Text = "";
            //запускаем проверку на сложность
            checkDifficultyAndCalculate(sender);
        }

        private void tbX_TextChanged(object sender, EventArgs e)
        {
            checkDifficultyAndCalculate(sender);
        }

        private void tbY_TextChanged(object sender, EventArgs e)
        {
            checkDifficultyAndCalculate(sender);
        }

        private void checkDifficultyAndCalculate(object sender)
        {
            IDisplayOperation sad;

            if ((sad = lbOperation.SelectedItem as IDisplayOperation) == null)
            {
                //значит операция старая и сложная
                lblResult.Text = "Операция сложная, нажмите ENTER, чтобы вычислить";
            }
            else
            {
                if (sad.Difficulty.ToString() != "Not")
                {
                    //значит операция новая,но сложная
                    lblResult.Text = "Операция сложная, нажмите ENTER, чтобы вычислить";
                }

                else
                {
                    LastPressTime = DateTime.Now;
                    timer1.Start();
                }
            }
        }

        private void tbX_KeyDown(object sender, KeyEventArgs e)
        {
            switchTb(sender, e.KeyCode);
        }

        private void tbY_KeyDown(object sender, KeyEventArgs e)
        {
            switchTb(sender, e.KeyCode);
        }

        private void switchTb(object sender, Keys kCode)
        {
            if (kCode == Keys.Enter || kCode == Keys.Tab)
            {
                if (tbX.Text == "")
                    tbX.Focus();
                else
                {
                    if (tbY.Text == "")
                        tbY.Focus();
                    else
                    {
                        LastPressTime = DateTime.Now;
                        timer1.Start();
                    }
                }
            }
        }

        private void tbX_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tbX, "Первая переменная, результат несложных функций вычисляется\nпри изменении данного значения, результат сложных функций\nвычисляется при нажатии ENTER.");
        }

        private void tbY_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tbY, "Вторая переменная, результат несложных функций вычисляется\nпри изменении данного значения, результат сложных функций\nвычисляется при нажатии ENTER.");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (LastPressTime.HasValue)
            {
                var diffTime = DateTime.Now - LastPressTime.Value;

                if (diffTime.TotalMilliseconds >= 250)
                {
                    Calculate(sender);
                    LastPressTime = null;
                    timer1.Stop();
                }
            }
        }
    }
}