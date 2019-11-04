<template>
  <crud-view
    title="Usuários"
    api-module="Users"
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
          name: "email",
          type: "text",
          placeholder: "E-mail"
        },
        {
          name: "login",
          type: "text",
          placeholder: "login"
        },
        {
          name: "password",
          type: "text",
          placeholder: "Senha"
        }        
      ]
    };
  }
};
</script>
