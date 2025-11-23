using System.Threading;
using System.Windows.Forms;

namespace Pratica5 {
    class OrdenacaoGrafica {
        // TODO: declarar demais métodos de ordenação
        public static void Bolha(int[] vet, Panel p) {
            int i, j, temp;
            for (i = 0; i < vet.Length - 1; i++) {
                for (j = vet.Length - 1; j > i; j--) {
                    if (vet[j] < vet[j - 1]) {
                        temp = vet[j];
                        vet[j] = vet[j - 1];
                        vet[j - 1] = temp;
                    }
                }
                p.Invalidate(); // força o redesenhamento do painel
                Thread.Sleep(10); // espera 10 milisegundos
            }
        }

    }
}
