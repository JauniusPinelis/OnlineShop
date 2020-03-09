﻿var app = new Vue({
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
            axios.get('/Admin/stock')
                .then(res => {
                    console.log(res);
                    this.products = res.data;
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false
                })
        },
        selectProduct(product) {
            this.selectedProduct = product;
            this.newStock.productId = productId;
        },
        updateStock() {

        },
        addStock() {
            this.loading = true;
            axios.post('/admin/stock', this.newStock)
                .then(res => {
                    console.log(res);
                    this.products.stock.push(res.data);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false
                })
        }


    }
})