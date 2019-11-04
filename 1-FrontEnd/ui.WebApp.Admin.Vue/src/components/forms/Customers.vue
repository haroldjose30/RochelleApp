<template>
  <crud-view
    title="Clientes"
    api-module="Customers"
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
          name: "Name",
          type: "text",
          placeholder: "Nome"
        },
        {
          name: "Email",
          type: "text",
          placeholder: "E-mail"
        },        
        {
          name: "BirthDate",
          type: "Date",
          placeholder: "Nascimento"
        },
        {
          name: "Document",
          type: "text",
          placeholder: "Cpf"
        },
        {
          name: "companyId",
          type: "text",
          placeholder: "companyId"
        }
      ]
    };
  }
};
</script>
