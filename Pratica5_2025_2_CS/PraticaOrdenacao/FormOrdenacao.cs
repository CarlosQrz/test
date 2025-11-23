using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Pratica5 {
    public partial class FormOrdenacao : Form {
        int[] vet = new int[500]; // vetor interno para a animação

        public FormOrdenacao() {
            InitializeComponent();
            panel.Paint += new PaintEventHandler(panel_Paint);
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, panel, new object[] { true });
        }

        private void panel_Paint(object sender, PaintEventArgs e) {
            for (int i = 0; i < vet.Length; i++) {
                e.Graphics.DrawLine(Pens.Red, i, 299, i, 299 - vet[i]);
            }
        }

        private void bolhaToolStripMenuItem_Click(object sender, EventArgs e) {
            iniciaAnimacao(() => OrdenacaoGrafica.Bolha(vet, panel));
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show(this, 
                "Prática 5 2025/2 - Métodos de Ordenação\n\n" +
                "Desenvolvido por:\n72401001 - Carlos Henrique Queiroz Ramos Teixeira\n" +
                "Prof. Virgílio Borges de Oliveira\n\n" +
                "Algoritmos e Estruturas de Dados\n" +
                "Faculdade COTEMIG\n" +
                "Apenas para fins didáticos.", 
                "Sobre o trabalho...", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }

        private void iniciaAnimacao(Action a) {
            if (bgw.IsBusy != true) {
                // TODO: escolher a ordenação inicial do vetor de acordo com o combobox do form
                Preenchimento.Aleatorio(vet, 300);
                bgw.RunWorkerAsync(a); // inicia a animação
            }
            else {
                MessageBox.Show(this,
                   "Aguarde o fim da execução atual...",
                   "Prática 5 2025/2 - Métodos de Ordenação",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation);
            }
        }

        private void bgw_DoWork(object sender, DoWorkEventArgs e) {
            Action a = (Action)e.Argument;
            a();
        }

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            MessageBox.Show(this,
               "Animação concluída!",
               "Prática 5 2025/2 - Métodos de Ordenação",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);
        }

        private void ordemInicial_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
