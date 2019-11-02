<template>
  <crud-view
    title="WeatherForecast"
    api-module="WeatherForecast"
    api-list-method="get_WeatherForecast"
    api-create-method=""
    api-update-method=""
    api-delete-method=""
    api-list-name="WeatherForecast"
    :object-model="objectModel"
  />
</template>
<script>
import CrudView from "../common/CrudView.vue";

export default {
  components: {
    CrudView
  },

  data() {
    return {
      objectModel: [
        {
          name: "date",
          type: "text",
          placeholder: "date"
        },
        {
          name: "temperatureC",
          type: "text",
          placeholder: "temperatureC"
        },
        {
          name: "temperatureF",
          type: "text",
          placeholder: "temperatureF"
        },
        {
          name: "summary",
          type: "text",
          placeholder: "summary"
        }
      ]
    };
  }
};
</script>
