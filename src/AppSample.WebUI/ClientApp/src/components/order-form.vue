<template>
  <div class="container mt-3">
    <h2>New order</h2>
    <b-form @submit="onSubmit" @reset="onReset" v-if="show">
      <b-form-group id="input-group-1" label="Date" label-for="input-1">
        <b-form-datepicker id="input-1" v-model="form.orderDate"></b-form-datepicker>
        <b-form-invalid-feedback :state="validDate">Please select a date</b-form-invalid-feedback>
      </b-form-group>

      <b-form-group id="input-group-2" label="Address:" label-for="input-2">
        <b-form-input
          id="input-2"
          v-model="form.clientAddress"
          required
          placeholder="Enter address"
        ></b-form-input>
        <b-form-invalid-feedback :state="validAddress">Address max length is 255 characters.</b-form-invalid-feedback>
      </b-form-group>

      <b-form-group id="input-group-3" label="Company:" label-for="input-3">
        <b-form-select id="input-3" v-model="form.companyId" :options="companyOptions" required></b-form-select>
      </b-form-group>

      <b-form-group id="input-group-4" label="Payment type:" label-for="input-4">
        <b-form-radio-group
          id="input-4"
          v-model="form.paymentTypeId"
          :options="paymentTypeOptions"
          required
        ></b-form-radio-group>
      </b-form-group>

      <b-form-group id="input-group-5">
        <b-form-checkbox id="input-5" v-model="form.isCompleted">Completed</b-form-checkbox>
      </b-form-group>

      <b-button type="submit" variant="primary">Submit</b-button>
      <b-button type="reset" variant="danger">Reset</b-button>
    </b-form>
  </div>
</template>

<script>
import {
  BForm,
  BFormGroup,
  BFormInput,
  BFormCheckbox,
  BButton,
  BFormSelect,
  BFormDatepicker,
  BFormRadioGroup,
  BFormInvalidFeedback
} from "bootstrap-vue";

import actions from "../store/actions";

export default {
  components: {
    "b-form": BForm,
    "b-form-group": BFormGroup,
    "b-form-input": BFormInput,
    "b-form-checkbox": BFormCheckbox,
    "b-button": BButton,
    "b-form-select": BFormSelect,
    "b-form-datepicker": BFormDatepicker,
    "b-form-radio-group": BFormRadioGroup,
    "b-form-invalid-feedback": BFormInvalidFeedback
  },
  data() {
    return {
      form: {
        orderDate: null,
        clientAddress: null,
        companyId: null,
        paymentTypeId: null,
        isCompleted: false
      },
      show: true
    };
  },
  methods: {
    onSubmit(evt) {
      evt.preventDefault();
      if (this.validForm) {
        const company = this.companyOptions.find(
          i => i.value === this.form.companyId
        );

        const paymentType = this.paymentTypeOptions.find(
          i => i.value === this.form.paymentTypeId
        );

        const order = {
          orderDate: this.form.orderDate,
          clientAddress: this.form.clientAddress,
          companyId: this.form.companyId,
          companyTitle: company ? company.text : null,
          paymentTypeId: this.form.paymentTypeId,
          paymentTypeTitle: paymentType ? paymentType.text : null,
          isCompleted: this.form.isCompleted
        };

        this.$store.dispatch(actions.SAVE_ORDER, order);
        this.$router.push("/");
      }
    },
    onReset(evt) {
      evt.preventDefault();
      // Reset our form values
      this.form.orderDate = null;
      this.form.clientAddress = null;
      this.form.companyId = null;
      this.form.paymentTypeId = null;
      this.form.isCompleted = false;
      // Trick to reset/clear native browser form validation state
      this.show = false;
      this.$nextTick(() => {
        this.show = true;
      });
    }
  },
  computed: {
    validAddress() {
      return this.form.clientAddress
        ? this.form.clientAddress.length < 256
        : true;
    },
    validDate() {
      return this.form.orderDate !== null;
    },
    validForm() {
      return this.validAddress && this.validDate;
    },
    companyOptions() {
      return this.$store.getters.companies
        ? [
            { text: "Select Company", value: null },
            ...this.$store.getters.companies.map(i => ({
              text: i.title,
              value: i.id
            }))
          ]
        : null;
    },
    paymentTypeOptions() {
      return this.$store.getters.paymentTypes
        ? this.$store.getters.paymentTypes.map(i => ({
            text: i.title,
            value: i.id
          }))
        : null;
    }
  },
  mounted() {
    this.$store.dispatch(actions.GET_COMPANIES);
    this.$store.dispatch(actions.GET_PAYMENT_TYPES);
  }
};
</script>
