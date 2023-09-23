<template>
  <div>
    <div class="masonry-with-columns mt-3">
      <div v-for="keep in keeps" :key="keep.id">
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

<style scoped lang="scss">
.masonry-with-columns {
  columns: 4 200px;
  column-gap: 1rem;

  div {
    width: 100px;
    margin: 0 .5rem 1rem 0;
    display: inline-block;
    width: 94%;
    text-align: center;
    border-radius: 3%;
  }
}

@media screen and (max-width: 769px) {
  .masonry-with-columns {
    columns: 2 100px;
    column-gap: 1rem;
  }
}
</style>