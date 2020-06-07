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
        paymentTypes: null,
        errorAlert: null,
        successAlert: null,
        successAlertCountdown: 0
    },

    getters: {
        orders: state => state.orders,
        companies: state => state.companies,
        paymentTypes: state => state.paymentTypes,
        errorAlert: state => state.errorAlert,
        successAlert: state => state.successAlert,
        successAlertCountdown: state => state.successAlertCountdown
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
        },

        [mutations.SET_ERROR_ALERT]: (state, payload) => {
            state.errorAlert = payload;
        },

        [mutations.SET_SUCCESS_ALERT]: (state, payload) => {
            state.successAlert = payload;
        },

        [mutations.SET_SUCCESS_ALERT_COUNTDOWN]: (state, payload) => {
            state.successAlertCountdown = payload;
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
            ApiClient.postOrder(order).then(response => {
                context.commit(mutations.ADD_ORDER, { ...order, id: response.data });
                context.commit(mutations.SET_SUCCESS_ALERT, "Order created");
                context.commit(mutations.SET_SUCCESS_ALERT_COUNTDOWN, 2);
            });
        },

        [actions.SET_ERROR_ALERT]: async (context, error) => {
            context.commit(mutations.SET_ERROR_ALERT, error);
        },

        [actions.SET_SUCCESS_ALERT]: async (context, error) => {
            context.commit(mutations.SET_SUCCESS_ALERT, error);
        },

        [actions.SET_SUCCESS_ALERT_COUNTDOWN]: async (context, countdown) => {
            context.commit(mutations.SET_SUCCESS_ALERT_COUNTDOWN, countdown);
        }
    }
});
