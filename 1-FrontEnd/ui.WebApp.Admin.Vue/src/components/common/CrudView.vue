<template>
  <div>
    <h2 class="text-center mt-5 mb-5" v-if="title">{{ title }}</h2>

    <div v-if="!loaded" class="text-center">
      <loader-icon class="spin-icon"/>
    </div>

    <b-alert
      variant="danger"
      dismissible
      :show="showObjectErrorAlert"
      @dismissed="showObjectErrorAlert=false"
    >{{errors}}</b-alert>

    <b-alert
      variant="success"
      dismissible
      :show="showObjectAddedAlert"
      @dismissed="showObjectAddedAlert=false"
    >Item cadastrado com sucesso.</b-alert>

    <b-alert
      variant="success"
      dismissible
      :show="showObjectDeletedAlert"
      @dismissed="showObjectDeletedAlert=false"
    >Item removido com sucesso.</b-alert>

    <form v-if="loaded" autocomplete="off">
      <table class="table table-add">
        <tbody>
          <tr v-if="objects.length > 0">
            <th v-if="allowReordering == true"></th>
            <th v-for="om in objectModel" v-bind:key="om.name">{{ om.placeholder }}</th>
            <th></th>
            <th class="extra-column-wrapper">
              <slot name="extra-column-header"></slot>
            </th>
            <th></th>
          </tr>

          <tr class="add-row">
            <td v-if="allowReordering == true"></td>
            <td class="align-middle" v-for="om in objectModel" v-bind:key="om.name">
              <b-form-input
                v-if="om.type == 'text'"
                v-model="om.value"
                type="text"
                :name="om.name"
                :placeholder="om.placeholder"
              />

              <b-form-input
                v-if="om.type == 'number'"
                v-model="om.value"
                type="text"
                :name="om.name"
                :placeholder="om.placeholder"
              />

              <b-form-input
                v-if="om.type == 'password'"
                v-model="om.value"
                type="password"
                :name="om.name"
                :placeholder="om.placeholder"
                :maxlength="om.maxlength"
              />

              <b-form-select
                class="dropdown"
                v-if="om.type == 'dropdown'"
                v-model="om.value"
                :options="om.options"
              >
                <template slot="first">
                  <option :value="null" disabled>Escolha uma opção</option>
                </template>
              </b-form-select>

              <b-form-checkbox
                v-if="om.type == 'boolean'"
                v-model="om.value"
                :name="om.name"
              >{{ om.placeholder }}</b-form-checkbox>

              <flag-check-box-group
                v-if="om.type == 'flag-checkbox-group'"
                :options="om.options"
                @flagsChanged="flags => om.value = flags"
              />
            </td>

            <td class="align-middle status"></td>
            <td class="align-middle text-left extra-column-wrapper">
              <slot name="extra-column-add"></slot>
            </td>
            <td class="align-middle text-right">
              <b-button
                class="action-button"
                type="submit"
                variant="success"
                @click.prevent="addObject"
              >
                <plus-icon class="feather-icon"/>Adicionar
              </b-button>
            </td>
          </tr>
        </tbody>
      </table>

      <b-row>
        <b-col md="12" class="d-flex flex-column mb-2">
          <b-pagination
            size="md"
            :total-rows="objects.length"
            v-model="currentPage"
            :per-page="perPage"
            class="align-self-center"
          ></b-pagination>
        </b-col>
      </b-row>

      <table class="table table-data">
        <tbody>
          <tr v-if="objects.length > 0">
            <th v-if="allowReordering == true"></th>
            <th v-for="om in objectModel" v-bind:key="om.name">{{ om.placeholder }}</th>
            <th></th>
            <th class="extra-column-wrapper"></th>
            <th></th>
          </tr>

          <tr class="filter-row">
            <td v-if="allowReordering == true"></td>
            <td class="align-middle" v-for="om in objectModel" v-bind:key="om.name">
              <b-form-select
                class="dropdown filter-dropdown"
                v-if="om.type == 'dropdown'"
                :options="om.options"
                @input="filter($event, om)"
                :value="null"
              >
                <template slot="first">
                  <option :value="null">Escolha um filtro</option>
                </template>
              </b-form-select>

              <b-form-input
                v-else-if="om.type !== 'fixed' && om.type !== 'flag-checkbox-group'"
                placeholder="Filtrar"
                @input="filter($event, om)"
                :class="{ 'filtered-input': !!filters[om.name] }" />
            </td>
            <td class="align-middle status"></td>
            <td class="align-middle text-left extra-column-wrapper"></td>
            <td class="align-middle text-right"></td>
          </tr>

          <tr
            v-for="object in filteredOrderedObjects.slice((currentPage-1)*perPage, currentPage*perPage)"
            v-bind:key="object.id">
            <td class="align-middle" v-if="allowReordering == true">
              <b-button variant="primary" size="sm" class="button-up" :disabled="arrowsDisabled" @click="moveUp(object)">
                <arrow-up-icon class="feather-icon"/>
              </b-button>

              <b-button variant="primary" size="sm" :disabled="arrowsDisabled" @click="moveDown(object)">
                <arrow-down-icon class="feather-icon"/>
              </b-button>
            </td>
            <td v-for="om in objectModel" v-bind:key="om.name" class="align-middle">
              <b-form-input
                v-if="!om.custom && om.type == 'text'"
                :disabled="om.disabled"
                type="text"
                v-model="object[om.name]"
                @input="fieldChanged(object)"
              />
              <b-form-input
                v-if="!om.custom && om.type == 'number'"
                :disabled="om.disabled"
                type="number"
                v-model="object[om.name]"
                @input="fieldChanged(object)"
              />
              <b-form-select
                class="dropdown"
                v-if="!om.custom && om.type == 'dropdown'"
                :disabled="om.disabled"
                v-model="object[om.name]"
                :options="om.options"
                @input="fieldChanged(object)"
              />
              <b-form-checkbox
                v-if="om.type == 'boolean'"
                v-model="object[om.name]"
                @input="fieldChanged(object)"
              >{{ om.placeholder }}</b-form-checkbox>
              <flag-check-box-group
                v-if="om.type == 'flag-checkbox-group'"
                :options="om.options"
                :flags="object[om.name]"
                @flagsChanged="flags => { object[om.name] = flags; fieldChanged(object) }"
              />
              <span v-if="om.type == 'fixed'">{{ om.computed(object) }}</span>
              <component
                v-if="om.custom"
                :is="om.custom"
                :object-id="object.id"
                @clicked="customComponentClicked"
              />
            </td>
            <td class="text-left extra-column-wrapper align-middle">
              <slot name="extra-column-body" :object="object"></slot>
            </td>
            <td class="align-middle status">
              <loader-icon v-if="object.dirty" class="spin-icon"/>
              <check-icon v-if="object.updated"/>
            </td>
            <td class="text-right align-middle">
              <delete-button class="action-button" @clicked="prepareDelete" :object="object"/>
            </td>
          </tr>
        </tbody>
      </table>
      <b-row>
        <b-col md="12" class="d-flex flex-column mb-5">
          <b-pagination
            size="md"
            :total-rows="objects.length"
            v-model="currentPage"
            :per-page="perPage"
            class="align-self-center"
          ></b-pagination>
        </b-col>
      </b-row>
    </form>
    <p v-if="loaded && objects.length == 0">Nenhum item cadastrado.</p>
    <b-modal
      id="confirm-delete-modal"
      body-text-variant="danger"
      ok-variant="danger"
      ok-title="Sim, remover"
      cancel-title="Não, cancelar"
      cancel-variant="primary"
      title="Remover item"
      @ok="deleteObject"
    >
      <strong>Tem certeza que deseja remover esse item?</strong>
    </b-modal>
  </div>
</template>

<script src="./CrudView.js"></script>
<style scoped src="./CrudView.css"></style>