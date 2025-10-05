import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

// Passo 1: Definir a interface para o nosso modelo de dados "Usuario"
export interface Usuario {
  id: number;
  nome: string;
  email: string;
  cidade: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  // Passo 2: A propriedade agora é um array de Usuários, começando vazio.
  public usuarios: Usuario[] = [];

  // A URL base da nossa API que criamos no backend .NET
  private apiUrl = '/api/usuarios';

  constructor(private http: HttpClient) { }

  // Passo 3: Método para buscar os usuários no backend
  buscarUsuarios(): void {
    this.http.get<Usuario[]>(this.apiUrl).subscribe(result => {
      this.usuarios = result; // Preenche o array com os dados recebidos
    }, error => {
      console.error('Erro ao buscar usuários:', error);
      alert('Falha ao buscar dados do servidor.');
    });
  }

  // Passo 4: Método para chamar o endpoint de exportação de CSV
  exportarParaCsv(): void {
    const exportUrl = `${this.apiUrl}/exportar-csv`;
    this.http.get(exportUrl, { responseType: 'blob' })
      .subscribe(blob => {
        const a = document.createElement('a');
        const objectUrl = URL.createObjectURL(blob);
        a.href = objectUrl;
        a.download = 'usuarios.csv';
        a.click();
        URL.revokeObjectURL(objectUrl);
      }, error => {
        console.error('Erro ao exportar CSV:', error);
        alert('Ocorreu um erro ao gerar o arquivo.');
      });
  }
}
