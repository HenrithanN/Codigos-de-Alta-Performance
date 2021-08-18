
let mensagem = document.querySelector('#mensagem');
let imagem = document.querySelector('#imagem');

function validar(expressao) {

    let pilha = [];

    for (let i = 0; i < expressao.length; i++) {
         letra = expressao[i]
      if (letra === "("|| letra === "[") {
        pilha = [letra, ...pilha];
      }
      if (letra === ")" || letra === "]") {
        if (pilha.length > 0) {
          pilha.shift();
        } else {
          return false;
        }
      }
    }

    return pilha.length === 0;
}

function validarExpressao(){
    
    let letra = document.querySelector('#expressao').value;
    let valido = validar(letra);


    if (valido) {
      mensagem.classList.remove('incorreto');
      imagem.classList.remove('imagemIncorreta');
      mensagem.classList.add('correto');
      imagem.classList.add('imagemCorreta');
      mensagem.innerHTML = 'Sua expressão está correta!';
    }
    else{
        mensagem.classList.remove('correto');
        imagem.classList.remove('imagemCorreta');
        mensagem.classList.add('incorreto');
        imagem.classList.add('imagemIncorreta');
        mensagem.innerHTML = 'Sua expressão está incorreta!';
    }

}