<template>
  <form @submit.prevent="createVault()">
    <div class="form-floating mb-3">
      <input type="text" class="form-control" required="editable.name" minlength="1" maxlength="255" id="vaultName"
        placeholder="Name of Vault" v-model="editable.name">
      <label for="vaultName">Vault Name</label>
    </div>
    <div class="form-floating mb-3">
      <input type="text" class="form-control" required="editable.img" maxlength="500" placeholder="Image here please"
        v-model="editable.img" id="vaultImg">
      <label for="vaultImg">Images</label>
    </div>
    <div class="form-floating mb-3">
      <textarea v-model="editable.description" required class="form-control" name="description" id="description"
        style="height:200px"></textarea>
      <label for="description">Description</label>
    </div>
    <div class="form-check">
      <input class="form-check-input" type="checkbox" role="switch" id="vaultIsPrivate" v-model="editable.isPrivate">
      <label class="form-check-label" for="vaultIsPrivate">Make Vault Private?</label>
    </div>
    <button class="btn btn-success" data-bs-target="#createVault" data-bs-toggle="modal">Create Vault</button>
  </form>
</template>


<script>
import { ref } from 'vue';
import Pop from '../utils/Pop.js';
import { vaultService } from '../services/VaultService.js';
import { useRoute } from 'vue-router';

export default {
  setup() {
    const editable = ref({})
    const route = useRoute();


    return {
      editable,

      // FIXME add route params profile Id here for the check to push into appstate....refer to fixme notes on createKeep
      async createVault() {
        try {
          if (!editable.value.isPrivate) {
            editable.value.isPrivate = false;
          }
          const profileId = route.params.profileId;
          await vaultService.createVault(editable.value, profileId)
          editable.value = {};
        } catch (error) {
          return Pop.error(error.message)

        }
      }
    }
  }
}
</script>


<style lang="scss" scoped></style>