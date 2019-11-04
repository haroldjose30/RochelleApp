<template>
  <crud-view
    title="Parametros de Configurações"
    api-module="ParamConfigurations"
    api-list-method="get"
    api-create-method="post"
    api-update-method="put"
    api-delete-method="delete"
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
          name: "id",
          type: "text",
          placeholder: "id"
        },
        {
          name: "name",
          type: "text",
          placeholder: "Parametro"
        },
        {
          name: "value",
          type: "text",
          placeholder: "Valor"
        },        
        {
          name: "type",
          type: "number",
          placeholder: "Tipo: 0=character / 1=number"
        }
      ]
    };
  }
};
</script>
