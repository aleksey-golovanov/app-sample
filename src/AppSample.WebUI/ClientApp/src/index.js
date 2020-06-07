import Vue from "vue";
import VueRouter from "vue-router";

import { store } from './store/store';

import App from "./components/app.vue";
import OrdersList from "./components/orders-list.vue";
import OrderForm from "./components/order-form.vue";

import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";

Vue.use(VueRouter);

const routes = [
    { path: '*', component: OrdersList },
    { path: '/new-order', component: OrderForm }
];

const router = new VueRouter({
    routes,
    mode: "history"
});

new Vue({
    el: "#app",
    render: h => h(App),
    components: { App },
    router,
    store
});
