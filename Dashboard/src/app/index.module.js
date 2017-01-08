import { config } from './index.config';
import { routerConfig } from './index.route';
import { MainController } from './main/main.controller';

angular.module('dashboard', ['ui.router', 'ui.bootstrap'])
  .config(config)
  .config(routerConfig)
  .controller('MainController', MainController);
