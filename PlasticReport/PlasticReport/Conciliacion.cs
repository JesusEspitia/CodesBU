using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlasticReport
{
    public partial class Conciliacion : Form
    {
        public Conciliacion()
        {
            InitializeComponent();
        }

        private void Conciliacion_Load(object sender, EventArgs e)
        {
            //write labels
            #region labels
            groupBox1.Text = "Rastreo";
            label2.Text = "1)Seleccionar fecha";
            label3.Text = "Seleccionar Máquina";
            label4.Text = "Seleccionar PN";
            label5.Text = "4)Seleccionar BATCH";
            rdTurno1.Text = "Turno 1";
            rdTurno2.Text = "Turno 2";
            btnCaptura.Text = "Capturar";
            btnCancel.Text = "Cancelar";
            btnPrint.Text = "Imprimir Etiquetas";
            label1.Text = "Capturar Información";
            #endregion
            #region labels_for_textbox
            label6.Text = "Ciclo STD Segundos(A):";
            label7.Text = "# Cavidades Molde(B):";
            label8.Text = "Peso - Pieza(Lb)(C):";
            label9.Text = "Prod. Plan/Hr (Pza) (D):";
            label10.Text = "Total de Scrap Libras (E):";
            label11.Text = "Total de Scrap Libras (Purgas) (F):";
            label12.Text = "Tiempo de ocio PLANEADO(G):";
            label13.Text = "Timepo de ocio NO PLANEADO(P):";
            label14.Text = "Tiempo por NO REQUERIMIENTO (Q):";
            label15.Text = "Ciclo Actual (H):";
            label16.Text = "Producción Real (I):";
            label17.Text = "Perdidas por ciclo (J):";
            label18.Text = "Perdidas por scrap Pzs (K):";
            label19.Text = "Perdidas por scrap pedo (L):";
            label20.Text = "Tiempo de producción buena (M):";
            label21.Text = "Tiempo de turno (N):";
            label22.Text = "Perdidas por errores en el reporte (O):";
            #endregion
            lbWeekNumber.Text = "Semana: ";
        }
    }
}
