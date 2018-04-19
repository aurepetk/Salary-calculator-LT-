using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalaryCalculator
{
    public partial class Form1 : Form
    {
        private const float MINIMALI_ALGA = 400;
        private const float SODRA = 0.03f;
        private const float PSD = 0.06f;
        private const float GMP = 0.15f;
        private const float GARANTINIS_FONDAS = 0.002f;
        private const float ILGALAIKIO_ISMOKOS = 0.005f;
        private const float DARBDAVIO_SODRA = 0.2748f;
        
        float atlyginimasPopieriuje;
        float atlyginimasIRankas;
        float autorinesPajamos;
        float procentasNuoAut;
        float autUzdarbis;
        float visoTab1;
        float gmp;
        float sodrai;
        float sveikatai;
        float atlyginimasRankose;
        float algaPopieriuje;
        float darbdavysMoka;
        float autIRankas;
        float autPopieriuje;
        float visoTab2;

        public Form1()
        {
            InitializeComponent();
        }

        //Tab1
        private void button_skaiciuotiTab1_Click(object sender, EventArgs e)
        {
            AtlyginimasIRankas();
        }

        private void AtlyginimasIRankas ()
        {
            atlyginimasPopieriuje = float.Parse(textBox_ivestiAntPopieriaus.Text);

            Gmp(atlyginimasPopieriuje);

            Sodrai(atlyginimasPopieriuje);

            Psd(atlyginimasPopieriuje);

            atlyginimasIRankas = atlyginimasPopieriuje - gmp - sodrai - sveikatai;

            DarbdavysMoka(atlyginimasPopieriuje);

            if (checkBox_autorinesSutartysTab1.CheckState == CheckState.Checked)
            {
                ApskaiciuotiAutorines();
                visoTab1 = atlyginimasIRankas + autUzdarbis;
                textBox_isvedaVisoIRankas.Text = visoTab1.ToString("0.00");
            }

            textBox_isvedaIRankas.Text = atlyginimasIRankas.ToString("0.00");
            textBox_isvedaSodrai.Text = sodrai.ToString("0.00");
            textBox_isvedaSveikatai.Text = sveikatai.ToString("0.00");
            textBox_isvedaDarbdaviui.Text = darbdavysMoka.ToString("0.00");
        }

        #region MATOMUMAS
        private void checkBox_autorinesSutartysTab1_CheckedChanged(object sender, EventArgs e)
        {
            label_autPajamosTab1.Visible = checkBox_autorinesSutartysTab1.Checked;
            textBox_ivestiAutorinesPopieriuje.Visible = checkBox_autorinesSutartysTab1.Checked;
            label_procNuoAut.Visible = checkBox_autorinesSutartysTab1.Checked;
            textBox_procNuoAutoriniu.Visible = checkBox_autorinesSutartysTab1.Checked;
            label_autUzdarbis.Visible = checkBox_autorinesSutartysTab1.Checked;
            textBox_isvedaAutoriniuAlga.Visible = checkBox_autorinesSutartysTab1.Checked;
            label_VisoTab1.Visible = checkBox_autorinesSutartysTab1.Checked;
            textBox_isvedaVisoIRankas.Visible = checkBox_autorinesSutartysTab1.Checked;            
        }
        #endregion

        private void button_isvalytiTab1_Click(object sender, EventArgs e)
        {
            Utilities.ResetAllControls(tabControl1.SelectedTab);
        }

        //Tab2
        private void button_skaiciuotiTab2_Click(object sender, EventArgs e)
        {
            AtlyginimasPopieriuje();
        }

        private void AtlyginimasPopieriuje()
        {
            atlyginimasRankose = float.Parse(textBox_ivestiIRankas.Text);

            if (atlyginimasRankose <= 361)
            {
                algaPopieriuje = 1.1976f * (atlyginimasRankose - 27);  
            }
            else
            {
                algaPopieriuje = 1.45985f * (atlyginimasRankose - 87);
            }

            Gmp(algaPopieriuje);

            Sodrai(algaPopieriuje);

            Psd(algaPopieriuje);

            DarbdavysMoka(algaPopieriuje);

            if (checkBox_autonominesTab2.CheckState == CheckState.Checked)
            {
                AutorinesPopieriuje();
                visoTab2 = algaPopieriuje + autPopieriuje;
                textBox_isvedaVisoTab2.Text = visoTab2.ToString("0.00");
            }

            textBox_isvedaAntPop.Text = algaPopieriuje.ToString("0.00");
            textBox_isvedaPajamuMok.Text = gmp.ToString("0.00");
            textBox_isvedaSodros.Text = sodrai.ToString("0.00");
            textBox_isvedaSveikatos.Text = sveikatai.ToString("0.00");
            textBox_isvedaDarbMokTab2.Text = darbdavysMoka.ToString("0.00");
        }

        #region MATOMUMAS
        private void checkBox_autonominesTab2_CheckedChanged(object sender, EventArgs e)
        {
            label_autSutTab2.Visible = checkBox_autonominesTab2.Checked;
            textBox_ivestiAutIRankas.Visible = checkBox_autonominesTab2.Checked;
            label_autAntPop.Visible = checkBox_autonominesTab2.Checked;
            textBox_isvedaAutAntPop.Visible = checkBox_autonominesTab2.Checked;
            label_visoAntPop.Visible = checkBox_autonominesTab2.Checked;
            textBox_isvedaVisoTab2.Visible = checkBox_autonominesTab2.Checked;
        }
        #endregion

        private void button4_Click(object sender, EventArgs e)
        {
            Utilities.ResetAllControls(tabControl1.SelectedTab);
        }

        //Bendriniai skaičiavimai
        private void DarbdavysMoka(float algaPopieriuje)
        {
            darbdavysMoka = algaPopieriuje + (algaPopieriuje * DARBDAVIO_SODRA) + (algaPopieriuje * SODRA)
                + (algaPopieriuje * GARANTINIS_FONDAS) + (algaPopieriuje * ILGALAIKIO_ISMOKOS);
        }

        private void Gmp (float atlyginimasPopieriuje)
        {
            gmp = (atlyginimasPopieriuje - (380 - (0.5f * (atlyginimasPopieriuje - MINIMALI_ALGA)))) * GMP;
        }

        private void Sodrai (float atlyginimasPopieriuje)
        {
            sodrai = atlyginimasPopieriuje * SODRA;
        }

        private void Psd (float atlyginimasPopieriuje)
        {
            sveikatai = atlyginimasPopieriuje * PSD;
        }

        private void ApskaiciuotiAutorines()
        {
            autorinesPajamos = float.Parse(textBox_ivestiAutorinesPopieriuje.Text);
            procentasNuoAut = float.Parse(textBox_procNuoAutoriniu.Text);
            autUzdarbis = autorinesPajamos - (autorinesPajamos * (procentasNuoAut / 100));

            textBox_isvedaAutoriniuAlga.Text = autUzdarbis.ToString("0.00");
        }

        private void AutorinesPopieriuje()
        {
            autIRankas = float.Parse(textBox_ivestiAutIRankas.Text);
            autPopieriuje = autIRankas / 0.621f;

            textBox_isvedaAutAntPop.Text = autPopieriuje.ToString("0.00");
        }

        //Reset Button
        public class Utilities
        {
            public static void ResetAllControls(Control form)
            {
                foreach (Control control in form.Controls)
                {
                    if (control is TextBox)
                    {
                        TextBox textBox = (TextBox)control;
                        textBox.Text = "0";
                    }

                    if (control is CheckBox)
                    {
                        CheckBox checkBox = (CheckBox)control;
                        checkBox.Checked = false;
                    }
                }
            }
        }

        #region TEXT_INPUT
        //Avoid other input except for numbers
        private void AllowOnlyNumbers(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)) {
                e.Handled = true;
            }
        }

        private void textBox_ivestiAntPopieriaus_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowOnlyNumbers(sender, e);
        }

        private void textBox_ivestiAutorinesPopieriuje_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowOnlyNumbers(sender, e);
        }

        private void textBox_procNuoAutoriniu_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowOnlyNumbers(sender, e);
        }

        private void textBox_ivestiIRankas_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowOnlyNumbers(sender, e);
        }

        private void textBox_ivestiAutIRankas_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowOnlyNumbers(sender, e);
        }
        #endregion
    }
}
