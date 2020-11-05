const publishedFeedbacks = { template: '<publishedFeedbacks></publishedFeedbacks>' }
const patientsFeedbacks = { template: '<patientsFeedbacks></patientsFeedbacks>' }

const router = new VueRouter({
	  mode: 'hash',
	  routes: [
		  { path: '/', name: 'publishedFeedbacks', component: publishedFeedbacks },
		  { path: '/patientsFeedbacks', name: 'patientsFeedbacks', component: patientsFeedbacks }
	  ]
});

var app = new Vue({
	router,
	el: '#careCureHospital'
});
