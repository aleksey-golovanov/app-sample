<template>
  <div>
    <div>
      <b-navbar type="dark" variant="dark">
        <b-navbar-nav>
          <b-navbar-brand to="/">Home</b-navbar-brand>
          <b-nav-item to="/">Orders list</b-nav-item>
          <b-nav-item to="/new-order">New order</b-nav-item>
        </b-navbar-nav>
      </b-navbar>
    </div>

    <router-view></router-view>

    <div class="fixed-bottom">
      <b-alert
        :show="errorAlert!==null"
        dismissible
        @dismissed="dissmissErrorAlert"
        variant="danger"
      >{{errorAlert}}</b-alert>
      <b-alert
        :show="successAlertCountdown"
        @dismissed="dissmissSuccessAlert"
        @dismiss-count-down="countDownChanged"
        variant="success"
      >{{successAlert}}</b-alert>
    </div>
  </div>
</template>
<script>
import {
  BNavbar,
  BNavbarNav,
  BNavbarBrand,
  BContainer,
  BRow,
  BCol,
  BNavItem,
  BAlert
} from "bootstrap-vue";
import actions from "../store/actions";
export default {
  computed: {
    errorAlert() {
      return this.$store.getters.errorAlert;
    },
    successAlert() {
      return this.$store.getters.successAlert;
    },
    successAlertCountdown() {
      return this.$store.getters.successAlertCountdown;
    }
  },
  methods: {
    dissmissErrorAlert() {
      this.$store.dispatch(actions.SET_ERROR_ALERT, null);
    },
    dissmissSuccessAlert() {
      this.$store.dispatch(actions.SET_SUCCESS_ALERT, null);
    },
    countDownChanged(dismissCountDown) {
      this.$store.dispatch(
        actions.SET_SUCCESS_ALERT_COUNTDOWN,
        dismissCountDown
      );
    }
  },
  components: {
    "b-navbar": BNavbar,
    "b-navbar-nav": BNavbarNav,
    "b-navbar-brand": BNavbarBrand,
    "b-container": BContainer,
    "b-row": BRow,
    "b-col": BCol,
    "b-nav-item": BNavItem,
    "b-alert": BAlert
  }
};
</script>
