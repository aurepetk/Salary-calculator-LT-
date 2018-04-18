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

        float atlyginimaspopieriuje;
        float gmp;
        float sodraitab1;
        float sveikataitab1;
        float atlyginimasirankas;
        float darbovietoskaina;
        float autorinespajamos;
        float procentasnuoaut;
        float autuzdarbis;
        float visotab1;

        private void button_skaiciuotiTab1_Click(object sender, EventArgs e)
        {
            AtlyginimasIRankas();
        }

        private void AtlyginimasIRankas ()
        {
            atlyginimaspopieriuje = float.Parse(textBox_ivestiAntPopieriaus.Text);

            gmp = (atlyginimaspopieriuje - (380 - (0.5f * (atlyginimaspopieriuje - 400))))
                * 0.15f;

            sodraitab1 = atlyginimaspopieriuje * 0.03f;

            sveikataitab1 = atlyginimaspopieriuje * 0.06f;

            atlyginimasirankas = atlyginimaspopieriuje - gmp - sodraitab1 - sveikataitab1;

            darbovietoskaina = atlyginimaspopieriuje + (atlyginimaspopieriuje * 0.2748f) +
                (atlyginimaspopieriuje * 0.03f) + (atlyginimaspopieriuje * 0.002f) +
                (atlyginimaspopieriuje * 0.005f);

            if (checkBox_autorinesSutartysTab1.CheckState == CheckState.Checked)
            {
                ApskaiciuotiAutorines();
                visotab1 = atlyginimasirankas + autuzdarbis;
                textBox_isvedaVisoIRankas.Text = visotab1.ToString();
            }

            textBox_isvedaIRankas.Text = atlyginimasirankas.ToString();
            textBox_isvedaSodrai.Text = sodraitab1.ToString();
            textBox_isvedaSveikatai.Text = sveikataitab1.ToString();
            textBox_isvedaDarbdaviui.Text = darbovietoskaina.ToString();
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

        private float ApskaiciuotiAutorines ()
        {
            autorinespajamos = float.Parse(textBox_ivestiAutorinesPopieriuje.Text);
            procentasnuoaut = float.Parse(textBox_procNuoAutoriniu.Text);
            autuzdarbis = autorinespajamos - (autorinespajamos * (procentasnuoaut / 100));
           
            textBox_isvedaAutoriniuAlga.Text = autuzdarbis.ToString();

            return autuzdarbis;
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
    }
}
