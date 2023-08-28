<template>
  <div @click="setActiveKeep(keepProp)" data-bs-toggle="modal" data-bs-target="#keepDetails" class="keep-card">
    <div class="keep-image" :style="{ backgroundImage: 'url(' + keepProp.img + ')' }">
    </div>
    <!-- <div class="keep-info">
      <h4 class="keep-creator">{{ keepProp.creator }}</h4>
      <h3 class="keep-name">{{ keepProp.name }}</h3>
    </div> -->
  </div>
</template>


<script>
import { Keep } from '../models/Keep.js';
import { keepsService } from '../services/KeepsService.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';

export default {

  props: {
    keepProp: { type: Keep, require: true }
  },
  setup() {


    return {
      setActiveKeep(keep) {
        try {
          keepsService.setActiveKeep(keep)
        } catch (error) {
          Pop.error(error.message)
          logger.log(error)
        }
      },
    }
  }
}
</script>


<style lang="scss" scoped>
.keep-card {
  cursor: pointer;
  display: flex;
  flex-direction: column;
  align-items: center;
  background-color: #f5f5f5;
  border-radius: 8px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  transition: transform 0.2s, box-shadow 0.2s;
}

.keep-card:hover {
  transform: translateY(-4px);
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}

.keep-image {
  width: 100%;
  height: 200px;
  background-size: cover;
  background-position: center;
  border-radius: 8px 8px 0 0;
  position: relative;
}

.like-icon {
  position: absolute;
  top: 10px;
  right: 10px;
  font-size: 24px;
  color: #00a86b;
  transition: color 0.2s;
}

.like-icon.liked {
  color: #ff5a5f;
}

.keep-info {
  padding: 16px;
  text-align: center;
}

.keep-name {
  color: #333;
  margin: 0;
  font-size: 18px;
  font-weight: bold;
}
</style>