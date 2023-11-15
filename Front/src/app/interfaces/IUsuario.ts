export interface IUsuario{
  id: string,
  email: string;
  senha: string
}


export interface iUsuarioCadastro{
  id: string,
  email: string,
  senha: string,
  nome: string,
  cpf: string
}

export interface iUsuarioFull{
  id: string,
  email: string,
  senha: string,
  nome: string,
  cpf: string,
  cep: string,
  rua: string,
  numero: number,
  bairro: string,
  cidade: string,
  estado: string,
  datanascimento: Date
}