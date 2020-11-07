const publishedFeedbacks = { template: '<publishedFeedbacks></publishedFeedbacks>' }
const patientsFeedbacks = { template: '<patientsFeedbacks></patientsFeedbacks>' }
const publishFeedback = { template: '<publishFeedback></publishFeedback>' }

const router = new VueRouter({
	  mode: 'hash',
	  routes: [
		  { path: '/', name: 'publishedFeedbacks', component: publishedFeedbacks },
		  { path: '/patientsFeedbacks', name: 'patientsFeedbacks', component: patientsFeedbacks },
		  { path: '/publishFeedback', name: 'publishFeedback', component: publishFeedback },
	  ]
});

var app = new Vue({
	router,
	el: '#careCureHospital'
});
