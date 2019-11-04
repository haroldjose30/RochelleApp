<template>
  <crud-view
    title="Produto ou Serviço"
    api-module="Products"
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
          placeholder: "Nome"
        },
        {
          name: "RegisterState",
          type: "number",
          placeholder: "Ativo"
        },
        {
          name: "ProductType",
          type: "number",
          placeholder: "Tipo"
        }      
      ]
    };
  }
};
</script>
