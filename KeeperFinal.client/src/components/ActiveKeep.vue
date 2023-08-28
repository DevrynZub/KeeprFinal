<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-md-6 col-12 d-flex ps-0">
        <img class="img-fluid rounded-start" :src="keep.img" alt="KEEP">
      </div>
      <div class="col-md-6 col-12">
        <div class="row">
          <div class="col-12 fs-3">
            <p>Keep Name: {{ keep.name }}</p>
            <p class="description rounded px-1">{{ name.description }}</p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { computed } from 'vue';
import { AppState } from '../AppState.js';

export default {
  setup() {




    return {
      keep: computed(() => AppState.activeKeep)
    }
  }
}
</script>


<style lang="scss" scoped>
.img {
  max-height: 60vh;
}

.description {
  background-color: gray;
  color: white;
}


.description {
  max-width: 40vh;
}
</style>