<template>
  <crud-view
    title="Companies"
    api-module="Companies"
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
          name: "companyName",
          type: "text",
          placeholder: "Razão Social"
        },
        {
          name: "fantasyName",
          type: "text",
          placeholder: "Nome Fantasia"
        },
        {
          name: "corporateNumber",
          type: "text",
          placeholder: "Numero de Inscriçao"
        },
        {
          name: "CreatedBy",
          type: "text",
          placeholder: "Usuário",
          value:"admin",
          readonly:true
        },
      ]
    };
  }
};
</script>
