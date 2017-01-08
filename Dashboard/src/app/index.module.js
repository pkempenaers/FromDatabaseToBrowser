import { config } from './index.config';
import { routerConfig } from './index.route';
import { MainController } from './main/main.controller';
import './modules/services/personService/personService.module'

angular.module('dashboard', [
	'ui.router',
	'ui.bootstrap',
	'personServiceModule'
])
  .config(config)
  .config(routerConfig)
  .controller('MainController', MainController);
