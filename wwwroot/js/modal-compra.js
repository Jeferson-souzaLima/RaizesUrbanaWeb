document.addEventListener('DOMContentLoaded', () => {
    const modal = document.getElementById('modal-compra');
    const closeModal = document.getElementById('close-modal');
    const btnsComprar = document.querySelectorAll('.btn-comprar');
    const nomeProdutoElem = document.getElementById('nome-produto');
    const precoUnidadeElem = document.getElementById('preco-unidade');
    const preco1 = document.getElementById('preco-1');
    const preco3 = document.getElementById('preco-3');
    const preco10 = document.getElementById('preco-10');
    const btnFinalizar = document.getElementById('btn-finalizar-compra');
    const formCompra = document.getElementById('form-compra');

    // Simulando dados de produto
    const produtos = {
        'Alface Lisa': { preco: 2.5, preco3: 7, preco10: 20 },
        'Alface Roxa': { preco: 3.0, preco3: 8, preco10: 25 },
        'Alface Crespa': { preco: 2.8, preco3: 7.5, preco10: 22 },
        'Alface Americana': { preco: 3.2, preco3: 9, preco10: 28 },
    };

    // Abrir modal ao clicar em comprar
    btnsComprar.forEach((btn) => {
        btn.addEventListener('click', (event) => {
            const nomeProduto = event.target.closest('.produto-card').querySelector('h2').innerText;
            const produto = produtos[nomeProduto];

            // Preencher informações no modal
            nomeProdutoElem.innerText = nomeProduto;
            precoUnidadeElem.innerText = produto.preco.toFixed(2);
            preco1.innerText = produto.preco.toFixed(2);
            preco3.innerText = produto.preco3.toFixed(2);
            preco10.innerText = produto.preco10.toFixed(2);

            modal.style.display = 'block';
        });
    });

    // Fechar modal
    closeModal.addEventListener('click', () => {
        modal.style.display = 'none';
    });

    // Finalizar Compra
    btnFinalizar.addEventListener('click', () => {
        const produto = nomeProdutoElem.innerText;
        const quantidade = document.querySelector('input[name="quantidade"]:checked').value;
        const formaPagamento = document.querySelector('input[name="FormaPagamento"]:checked').value;

        // Atualizar campos ocultos no formulário com os dados selecionados
        document.getElementById('produto').value = produto;
        document.getElementById('preco-total').value = parseFloat(precoUnidadeElem.innerText) * quantidade;

        // Adicionar os dados ao formulário
        formCompra.submit();
    });

    // Fechar modal ao clicar fora
    window.addEventListener('click', (event) => {
        if (event.target === modal) {
            modal.style.display = 'none';
        }
    });
});


