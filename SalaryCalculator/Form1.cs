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
        public Form1()
        {
            InitializeComponent();
        }

        float atlyginimasPopieriuje;
        float gmpTab1;
        float sodraiTab1;
        float sveikataiTab1;
        float atlyginimasIRankas;
        float darboVietosKaina;
        float autorinesPajamos;
        float procentasNuoAut;
        float autUzdarbis;
        float visoTab1;

        private void button_skaiciuotiTab1_Click(object sender, EventArgs e)
        {
            AtlyginimasIRankas();
        }

        private void AtlyginimasIRankas ()
        {
            atlyginimasPopieriuje = float.Parse(textBox_ivestiAntPopieriaus.Text);

            gmpTab1 = (atlyginimasPopieriuje - (380 - (0.5f * (atlyginimasPopieriuje - 400))))
                * 0.15f;

            sodraiTab1 = atlyginimasPopieriuje * 0.03f;

            sveikataiTab1 = atlyginimasPopieriuje * 0.06f;

            atlyginimasIRankas = atlyginimasPopieriuje - gmpTab1 - sodraiTab1 - sveikataiTab1;

            darboVietosKaina = atlyginimasPopieriuje + (atlyginimasPopieriuje * 0.2748f) +
                (atlyginimasPopieriuje * 0.03f) + (atlyginimasPopieriuje * 0.002f) +
                (atlyginimasPopieriuje * 0.005f);

            if (checkBox_autorinesSutartysTab1.CheckState == CheckState.Checked)
            {
                ApskaiciuotiAutorines();
                visoTab1 = atlyginimasIRankas + autUzdarbis;
                textBox_isvedaVisoIRankas.Text = visoTab1.ToString("0.00");
            }

            textBox_isvedaIRankas.Text = atlyginimasIRankas.ToString("0.00");
            textBox_isvedaSodrai.Text = sodraiTab1.ToString("0.00");
            textBox_isvedaSveikatai.Text = sveikataiTab1.ToString("0.00");
            textBox_isvedaDarbdaviui.Text = darboVietosKaina.ToString("0.00");
        }

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

        private void ApskaiciuotiAutorines ()
        {
            autorinesPajamos = float.Parse(textBox_ivestiAutorinesPopieriuje.Text);
            procentasNuoAut = float.Parse(textBox_procNuoAutoriniu.Text);
            autUzdarbis = autorinesPajamos - (autorinesPajamos * (procentasNuoAut / 100));
           
            textBox_isvedaAutoriniuAlga.Text = autUzdarbis.ToString("0.00");
        }

        private void textBox_ivestiAutorinesPopieriuje_TextChanged(object sender, EventArgs e) => 
            textBox_ivestiAutorinesPopieriuje.Visible = checkBox_autorinesSutartysTab1.Checked;
            
        private void label_autPajamosTab1_Click(object sender, EventArgs e) => 
            label_autPajamosTab1.Visible = checkBox_autorinesSutartysTab1.Checked;

        private void label_procNuoAut_Click(object sender, EventArgs e) =>
            label_procNuoAut.Visible = checkBox_autorinesSutartysTab1.Checked;

        private void textBox_procNuoAutoriniu_TextChanged(object sender, EventArgs e) => 
            textBox_procNuoAutoriniu.Visible = checkBox_autorinesSutartysTab1.Checked;
           
        private void label_autUzdarbis_Click(object sender, EventArgs e) =>
            label_autUzdarbis.Visible = checkBox_autorinesSutartysTab1.Checked;

        private void textBox_isvedaAutoriniuAlga_TextChanged(object sender, EventArgs e) =>
            textBox_isvedaAutoriniuAlga.Visible = checkBox_autorinesSutartysTab1.Checked;

        private void label_VisoTab1_Click(object sender, EventArgs e) =>
            label_VisoTab1.Visible = checkBox_autorinesSutartysTab1.Checked;

        private void textBox_isvedaVisoIRankas_TextChanged(object sender, EventArgs e) =>
            textBox_isvedaVisoIRankas.Visible = checkBox_autorinesSutartysTab1.Checked;

        private void button_isvalytiTab1_Click(object sender, EventArgs e)
        {
            Utilities.ResetAllControls(tabControl1.SelectedTab);
        }

        //Tab2
        float atlyginimasRankose;
        float algaPopieriuje;
        float gmpTab2;
        float sveikataiTab2;
        float sodraiTab2;
        float darbdavysmoka;
        float autIRankas;
        float autPopieriuje;
        float visoTab2;

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

            gmpTab2 = (algaPopieriuje - (380 - (0.5f * (algaPopieriuje - 400)))) * 0.15f;

            sodraiTab2 = algaPopieriuje * 0.03f;

            sveikataiTab2 = algaPopieriuje * 0.06f;

            darbdavysmoka = algaPopieriuje + (algaPopieriuje * 0.2748f) +
                (algaPopieriuje * 0.03f) + (algaPopieriuje * 0.002f) +
                (algaPopieriuje * 0.005f);

            if (checkBox_autonominesTab2.CheckState == CheckState.Checked)
            {
                AutorinesPopieriuje();
                visoTab2 = algaPopieriuje + autPopieriuje;
                textBox_isvedaVisoTab2.Text = visoTab2.ToString("0.00");
            }

            textBox_isvedaAntPop.Text = algaPopieriuje.ToString("0.00");
            textBox_isvedaPajamuMok.Text = gmpTab2.ToString("0.00");
            textBox_isvedaSodros.Text = sodraiTab2.ToString("0.00");
            textBox_isvedaSveikatos.Text = sveikataiTab2.ToString("0.00");
            textBox_isvedaDarbMokTab2.Text = darbdavysmoka.ToString("0.00");
        }

        private void checkBox_autonominesTab2_CheckedChanged(object sender, EventArgs e)
        {
            label_autSutTab2.Visible = checkBox_autonominesTab2.Checked;
            textBox_ivestiAutIRankas.Visible = checkBox_autonominesTab2.Checked;
            label_autAntPop.Visible = checkBox_autonominesTab2.Checked;
            textBox_isvedaAutAntPop.Visible = checkBox_autonominesTab2.Checked;
            label_visoAntPop.Visible = checkBox_autonominesTab2.Checked;
            textBox_isvedaVisoTab2.Visible = checkBox_autonominesTab2.Checked;
        }

        private void AutorinesPopieriuje ()
        {
            autIRankas = float.Parse(textBox_ivestiAutIRankas.Text);
            autPopieriuje = autIRankas / 0.621f;

            textBox_isvedaAutAntPop.Text = autPopieriuje.ToString("0.00");
        }

        private void label_autSutTab2_Click(object sender, EventArgs e) =>
            label_autSutTab2.Visible = checkBox_autonominesTab2.Checked;

        private void textBox_ivestiAutIRankas_TextChanged(object sender, EventArgs e) =>
            textBox_ivestiAutIRankas.Visible = checkBox_autonominesTab2.Checked;

        private void label_autAntPop_Click(object sender, EventArgs e) =>
            label_autAntPop.Visible = checkBox_autonominesTab2.Checked;

        private void textBox_isvedaAutAntPop_TextChanged(object sender, EventArgs e) =>
            textBox_isvedaAutAntPop.Visible = checkBox_autonominesTab2.Checked;

        private void label_visoAntPop_Click(object sender, EventArgs e) =>
            label_visoAntPop.Visible = checkBox_autonominesTab2.Checked;

        private void textBox_isvedaVisoTab2_TextChanged(object sender, EventArgs e) =>
            textBox_isvedaVisoTab2.Visible = checkBox_autonominesTab2.Checked;

        private void button4_Click(object sender, EventArgs e)
        {
            Utilities.ResetAllControls(tabControl1.SelectedTab);
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
                        textBox.Text = null;
                    }

                    if (control is CheckBox)
                    {
                        CheckBox checkBox = (CheckBox)control;
                        checkBox.Checked = false;
                    }
                }
            }
        }

        //Avoid other input than numbers
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


    }
}
