const publishedFeedbacks = { template: '<publishedFeedbacks></publishedFeedbacks>' }
const patientsFeedbacks = { template: '<patientsFeedbacks></patientsFeedbacks>' }
const postFeedback = { template: '<postFeedback></postFeedback>' }
const patientRegistration = { template: '<patientRegistration></patientRegistration>' }
const surveyAfterExamination = { template: '<surveyAfterExamination></surveyAfterExamination>' }
const surveyResults = { template: '<surveyResults></surveyResults>' }
const doctorSurveyResults = { template: '<doctorSurveyResults></doctorSurveyResults>'}
const medicalRecordReview = { template: '<medicalRecordReview></medicalRecordReview>' }

const router = new VueRouter({
	mode: 'hash',
	routes: [
		{ path: '/', name: 'publishedFeedbacks', component: publishedFeedbacks },
		{ path: '/patientsFeedbacks', name: 'patientsFeedbacks', component: patientsFeedbacks },
		{ path: '/postFeedback', name: 'postFeedback', component: postFeedback },
		{ path: '/patientRegistration', name: 'patientRegistration', component: patientRegistration },
		{ path: '/surveyAfterExamination', name: 'surveyAfterExamination', component: surveyAfterExamination },
		{ path: '/surveyResults', name: 'surveyResults', component: surveyResults },
		{ path: '/doctorSurveyResults', name: 'doctorSurveyResults', component: doctorSurveyResults },
		{ path: '/medicalRecordReview', name: 'medicalRecordReview', component: medicalRecordReview }
	]
});

var app = new Vue({
	router,
	el: '#careCureHospital'
});
