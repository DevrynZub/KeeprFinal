<template>
  <form @submit.prevent="createKeep()">
    <div class="form-floating mb-3">
      <input type="text" class="form-control" required="editable.name" minlength="1" maxlength="255" id="keepName"
        placeholder="Name of Recipe" v-model="editable.name">
      <label for="keepName">Keep Name</label>
    </div>
    <div class="form-floating mb-3">
      <input type="text" class="form-control" required="editable.img" maxlength="500" placeholder="Image here please"
        v-model="editable.img" id="keepImg">
      <label for="keepImg">Images</label>
    </div>
    <div class="form-floating mb-3">
      <textarea v-model="editable.description" required class="form-control" name="description" id="description"
        style="height:200px"></textarea>
      <label for="description">Description</label>
    </div>
    <button class="btn back-button" data-bs-target="#createKeep" data-bs-toggle="modal">Create Keep</button>
  </form>
</template>


<script>
import { ref } from 'vue';
import Pop from '../utils/Pop.js';
import { keepsService } from '../services/KeepsService.js';

export default {
  setup() {
    const editable = ref({})


    return {
      editable,

      async createKeep() {
        try {
          await keepsService.createKeep(editable.value)
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