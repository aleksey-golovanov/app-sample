<template>
  <div class="container mt-3">
    <div class="row">
      <div class="col-lg">
        <div class="row">
          <div class="col-lg-9 mb-2">
            <h2>Orders</h2>
          </div>
          <div class="col-lg-3 mb-2">
            <b-form-group>
              <b-input-group size="sm">
                <b-form-input v-model="filter" type="search" placeholder="Type to Search"></b-form-input>
                <b-input-group-append>
                  <b-button :disabled="!filter" @click="filter = ''">Clear</b-button>
                </b-input-group-append>
              </b-input-group>
            </b-form-group>
          </div>
        </div>

        <div class="row">
          <div class="col-lg-6 mb-2">
            <b-button size="sm" to="/new-order" variant="primary">New order</b-button>
          </div>
          <div class="col-lg-6 mb-2">
            <b-pagination
              v-model="currentPage"
              :total-rows="totalRows"
              :per-page="perPage"
              align="fill"
              size="sm"
              class="my-0"
            ></b-pagination>
          </div>
        </div>
        <div class="row">
          <div v-if="orders !== null" class="col-lg-12">
            <b-table
              v-if="orders.length > 0"
              striped
              borderless
              small
              :items="orders"
              :fields="fields"
              :current-page="currentPage"
              :per-page="perPage"
              :filter="filter"
            >
              <template v-slot:cell(isCompleted)="data">
                <b-icon-check v-if="data.value" variant="success"></b-icon-check>
              </template>
              <template v-slot:cell(orderDate)="data">{{getFormattedDate(data.value)}}</template>
            </b-table>
            <div v-if="orders.length === 0">No orders found</div>
          </div>
          <div v-if="orders === null" class="col-lg-12">
            <b-spinner label="Loading..."></b-spinner>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import {
  BTable,
  BIconCheck,
  BPagination,
  BFormGroup,
  BInputGroup,
  BFormInput,
  BInputGroupAppend,
  BButton,
  BSpinner
} from "bootstrap-vue";
import actions from "../store/actions";
export default {
  components: {
    "b-table": BTable,
    "b-icon-check": BIconCheck,
    "b-pagination": BPagination,
    "b-form-group": BFormGroup,
    "b-input-group": BInputGroup,
    "b-form-input": BFormInput,
    "b-input-group-append": BInputGroupAppend,
    "b-button": BButton,
    "b-spinner": BSpinner
  },
  methods: {
    getFormattedDate(dateString) {
      const d = new Date(dateString);
      return `${`0${d.getDate()}`.slice(-2)}.${`0${d.getMonth() + 1}`.slice(
        -2
      )}.${d.getFullYear()}`;
    }
  },
  mounted() {
    this.$store.dispatch(actions.GET_ORDERS);
  },
  computed: {
    orders() {
      return this.$store.getters.orders;
    },
    totalRows() {
      return this.$store.getters.orders ? this.$store.getters.orders.length : 0;
    }
  },
  data() {
    return {
      fields: [
        {
          key: "orderDate",
          label: "Date"
        },
        {
          key: "clientAddress",
          label: "Client address"
        },
        {
          key: "companyTitle",
          label: "Company"
        },
        {
          key: "paymentTypeTitle",
          label: "Payment type"
        },
        {
          key: "isCompleted",
          label: "Completed"
        }
      ],
      currentPage: 1,
      perPage: 5,
      filter: null
    };
  }
};
</script>
