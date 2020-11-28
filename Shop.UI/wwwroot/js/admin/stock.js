var app = new Vue({
    el: '#app',
    data: {
        products: [],
        selectedProduct: null,
        newStock: {
            productId: 0,
            description: "Size",
            qty: 10
        }
    },
    mounted() {
        this.getStock()
    },
    methods: {
        getStock() {
            this.loading = true;
            axios.get('/Admin/stocks')
                .then(res => {
                    console.log(res)
                    this.products = res.data;
                })
                .catch(err => {
                    console.log(err)    
                })
                .then(() => {
                    this.loading = false;
                })
        },
        updateStock() {
            this.loading = true;
            axios.put('/Admin/stocks', {
                stock: this.selectedProduct.stock.Map(s => {
                    return {
                        id: s.id,
                        description: s.description,
                        qty: s.qty,
                        productId: this.selectProduct.id
                    };
                });
            })
                .then(res => {
                    console.log(res)
                    this.selectedProduct.stock.splice(index, 1);
                })
                .catch(err => {
                    console.log(err)
                })
                .then(() => {
                    this.loading = false;
                })
        },

        deleteStock(id, index) {
            this.loading = true;
            axios.delete('/Admin/stocks' + id)
                .then(res => {
                    console.log(res)
                    this.selectedProduct.stock.splice(index, 1);
                })
                .catch(err => {
                    console.log(err)
                })
                .then(() => {
                    this.loading = false;
                })
        },
        addStock() {
            this.loading = true;
            console.log('add stock called')
            console.log(this.newStock)

            axios.post('/Admin/stocks', this.newStock)
                .then(res => {
                    console.log(res)
                    this.selectedProduct.stock.push(res.data);
                })
                .catch(err => {
                    console.log(err)
                })
                .then(() => {
                    this.loading = false;
                })
        },
        selectProduct(product) {
            console.log('selectProduct:')
            console.log(product)
            console.log('selectedProduct.id = ', product.id)

            this.selectedProduct = product;
            this.newStock.productId = product.id
            console.log('newStock.productId = ', product.id)
        }
    }
})