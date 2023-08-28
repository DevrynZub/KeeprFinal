<template>
  <div class="container-fluid">
    <div class="row p-2">
      <div class="col-md-4 col-12 mb-3" v-for="keep in keeps" :key="keep.id">

      </div>
    </div>
  </div>
</template>

<script>
import Pop from '../utils/Pop.js';
import { keepsService } from '../services/KeepsService.js'
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';

export default {
  setup() {

    async function getKeeps() {
      try {
        await keepsService.getKeeps()
      } catch (error) {
        Pop.error('[Error]', error.message)
      }
    }


    onMounted(() => {
      getKeeps()
    })



    return {
      keeps: computed(() => AppState.keeps)
    }
  }
}
</script>

<style scoped lang="scss"></style>
