const publishedFeedbacks = { template: '<publishedFeedbacks></publishedFeedbacks>' }
const patientsFeedbacks = { template: '<patientsFeedbacks></patientsFeedbacks>' }
const postFeedback = { template: '<postFeedback></postFeedback>' }
const patientRegistration = { template: '<patientRegistration></patientRegistration>' }
const surveyAfterExamination = { template: '<surveyAfterExamination></surveyAfterExamination>' }
const surveyResults = { template: '<surveyResults></surveyResults>' }
const doctorSurveyResults = { template: '<doctorSurveyResults></doctorSurveyResults>'}
const medicalRecordReview = { template: '<medicalRecordReview></medicalRecordReview>' }
const patientDocumentsAdvancedSearch = { template: '<patientDocumentsAdvancedSearch></patientDocumentsAdvancedSearch>' }
const patientDocumentsSimpleSearch = { template: '<patientDocumentsSimpleSearch></patientDocumentsSimpleSearch>' }
const appointmentSchedulingByRecommendation = { template: '<appointmentSchedulingByRecommendation></appointmentSchedulingByRecommendation>' }
const patientAppointments = { template: '<patientAppointments></patientAppointments>' }

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
		{ path: '/medicalRecordReview', name: 'medicalRecordReview', component: medicalRecordReview },
		{ path: '/medicalRecordReview', name: 'medicalRecordReview', component: medicalRecordReview },
		{ path: '/patientDocumentsAdvancedSearch', name: 'patientDocumentsAdvancedSearch', component: patientDocumentsAdvancedSearch },
		{ path: '/patientDocumentsSimpleSearch', name: 'patientDocumentsSimpleSearch', component: patientDocumentsSimpleSearch },
		{ path: '/appointmentSchedulingByRecommendation', name: 'appointmentSchedulingByRecommendation', component: appointmentSchedulingByRecommendation },
		{ path: '/patientAppointments', name: 'patientAppointments', component: patientAppointments }
	]
});

var app = new Vue({
	router,
	el: '#careCureHospital'
});
