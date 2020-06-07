import Vue from "vue";
import Vuex from "vuex";
import ApiClient from "../api-client";
import actions from "./actions";
import mutations from "./mutations";

Vue.use(Vuex);

export const store = new Vuex.Store({
    state: {
        orders: null,
        companies: null,
        paymentTypes: null
    },

    getters: {
        orders: state => state.orders,
        companies: state => state.companies,
        paymentTypes: state => state.paymentTypes
    },

    mutations: {
        [mutations.SET_ORDERS]: (state, payload) => {
            state.orders = payload;
        },

        [mutations.SET_COMPANIES]: (state, payload) => {
            state.companies = payload;
        },

        [mutations.SET_PAYMENT_TYPES]: (state, payload) => {
            state.paymentTypes = payload;
        },

        [mutations.ADD_ORDER]: (state, payload) => {
            state.orders.push(payload);
        }
    },

    actions: {
        [actions.GET_ORDERS]: async context => {
            ApiClient.getOrders().then(response => { context.commit(mutations.SET_ORDERS, response.data) });
        },

        [actions.GET_COMPANIES]: async context => {
            ApiClient.getCompanies().then(response => { context.commit(mutations.SET_COMPANIES, response.data) });
        },

        [actions.GET_PAYMENT_TYPES]: async context => {
            ApiClient.getPaymentTypes().then(response => { context.commit(mutations.SET_PAYMENT_TYPES, response.data) });
        },

        [actions.SAVE_ORDER]: async (context, order) => {
            ApiClient.postOrder(order).then(response => context.commit(mutations.ADD_ORDER, { ...order, id: response.data }));
        }
    }
});
