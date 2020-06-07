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
  BNavItem
} from "bootstrap-vue";
export default {
  components: {
    "b-navbar": BNavbar,
    "b-navbar-nav": BNavbarNav,
    "b-navbar-brand": BNavbarBrand,
    "b-container": BContainer,
    "b-row": BRow,
    "b-col": BCol,
    "b-nav-item": BNavItem
  }
};
</script>
