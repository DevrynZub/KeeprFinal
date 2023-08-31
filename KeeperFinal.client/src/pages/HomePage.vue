<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-12">
      </div>
    </div>
    <div class="row p-2">
      <div class="col-md-4 col-12 mb-3" v-for="keep in keeps" :key="keep.id">
        <KeepCard :keepProp="keep" />
      </div>
    </div>
  </div>
</template>

<script>
import Pop from '../utils/Pop.js';
import { keepsService } from '../services/KeepsService.js'
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';
import KeepCard from '../components/KeepCard.vue';
import { useRoute } from 'vue-router';

export default {
  setup() {
    const route = useRoute()

    async function getKeeps() {
      try {
        await keepsService.getKeeps();
      }
      catch (error) {
        Pop.error('[Error]', error.message);
      }
    }



    onMounted(() => {
      route.params.keepId
      getKeeps();
    });
    return {
      keeps: computed(() => AppState.keeps)
    };
  },



  components: { KeepCard }
}
</script>

<style scoped lang="scss"></style>
