using CADASTRODEPESSOAFS.Classes;

PessoaFisica novaPf = new PessoaFisica();
PessoaFisica metodoPf = new PessoaFisica();
Endereco novoEnd = new Endereco();


novaPf.nome = "ismael";
novaPf.cpf = "06376564585";
novaPf.rendimento = 1000.5f;
novaPf.dataNasc = new DateTime(1996, 04, 05);


novoEnd.logradouro = "Rua K";
novoEnd.numero = 291;
novoEnd.cep = 49043236;
novoEnd.endComercial = false;

novaPf.endereco = novoEnd;

Console.WriteLine(@$"
Nome: {novaPf.nome}
CPF: {novaPf.cpf}
Data de Nascimento: {novaPf.dataNasc} maior de idade: {(metodoPf.ValidarDataNascimento(novaPf.dataNasc)? "sim" : "Não")}
Endereço: {novaPf.endereco.logradouro}, {novaPf.endereco.numero}, {novaPf.endereco.cep}
Redimento: {novaPf.rendimento.ToString("C")}
Taxa de imposto a ser pago é: 
");
