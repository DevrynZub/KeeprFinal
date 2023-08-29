<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-md-6 col-12 d-flex ps-0">
        <img class="img-fluid rounded-start keep-image" :src="keep.img" alt="KEEP">
      </div>
      <div class="col-md-6 col-12 d-flex align-items-center">
        <div class="row">
          <div class="col-12 fs-3">
            <div class="d-flex justify-content-evenly mb-3">
              <p class="mdi mdi-eye-outline">{{ keep.views }}</p>
              <p class="mdi mdi-safe">{{ keep.kept }}</p>
            </div>

            <div class="text-center">
              <p class="keep-name">{{ keep.name }}</p>
              <p class="description rounded px-1">{{ keep.description }}</p>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <!-- Save button and dropdown menu here -->
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
.keep-image {
  width: 100%;
  object-fit: cover;
}

.keep-name {
  font-size: 1.5rem;
  font-weight: bold;
  margin-bottom: 10px;
}
</style>