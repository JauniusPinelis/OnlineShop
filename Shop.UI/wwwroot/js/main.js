var app = new Vue({
    el: "#app",
    data: {
        price: 0,
        index: 0,
        showPrice: false,
        productModel: {
            id: 0,
            name: "Product Name",
            description: "Product Description",
            value: 1.99
        },
        loading: false,
        products: []
    },
    mounted() {
        this.getProducts();
    },
    methods: {
        togglePrice: function () {
            this.showPrice = !this.showPrice;
        },
        alert(v) {
            alert(v)
        },
        getProducts() {
            this.loading = true;
            axios.get('/Admin/products')
                .then(res => {
                    console.log(res);
                    this.products = res.data
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false
                })
        },
        getProduct(id) {
            this.loading = true;
            axios.get('/Admin/products/' + id)
                .then(res => {
                    console.log(res);
                    this.product = res.data
                    this.productModel = {
                        id: this.product.id,
                        name: this.product.name,
                        description: this.product.description,
                        value: this.product.value
                    };
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false
                })
        },
        createProduct() {
            this.loading = true;
            axios.post('/Admin/products', this.productModel)
                .then(res => {
                    console.log(res);
                    this.products.push(res.data);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false
                })
        },
        editProduct(id, index) {
            this.objectIndex = index;
            this.getProduct(id);
        },
        updateProduct() {
            this.loading = true;
            axios.put('/Admin/products', this.productModel)
                .then(res => {
                    console.log(res);
                    this.products.splice(this.objectIndex,1 , res.data);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false
                })
        },
        deleteProduct(id, index) {
            this.loading = true;
            axios.get('/Admin/products/' + id)
                .then(res => {
                    console.log(res);
                    this.products.splice(index, 1);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false
                })
        }


    },
    computed: {
        formatPrice: function(){
            return "$" + this.price;
        }
    }
});