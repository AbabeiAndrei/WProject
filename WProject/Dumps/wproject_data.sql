DELETE FROM `access_object`;
INSERT INTO `access_object` (`id`, `name`, `code`, `metadata`, `deleted`) VALUES
	(1, 'AccessProject', 'WProject.Access.Project', NULL, NULL),
	(2, 'AccessProject', 'WProject.Access.Project', NULL, NULL),
	(3, 'AccessProjectSettings', 'WProject.Access.Project.Settings', NULL, NULL),
	(4, 'AccessProjectSettingsUser', 'WProject.Access.Project.Settings.User', NULL, NULL),
	(5, 'AccessProjectSettingsGroup', 'WProject.Access.Project.Settings.Group', NULL, NULL),
	(6, 'AccessProjectSettingsAccess', 'WProject.Access.Project.Settings.Access', NULL, NULL),
	(7, 'AccessProjectSettingsDictItem', 'WProject.Access.Project.Settings.DictItem', NULL, NULL),
	(8, 'AccessBacklog', 'WProject.Access.Backlog', NULL, NULL),
	(9, 'AccessTask', 'WProject.Access.Project.Task', NULL, NULL);


DELETE FROM `dict_item`;
INSERT INTO `dict_item` (`id`, `name`, `description`, `type`, `parent_id`, `reserved`, `code`, `order`, `color`, `tag`, `deleted`) VALUES
	(1, 'Task', NULL, 'TSK_TYPE', NULL, NULL, 'TASK', 0, NULL, NULL, NULL),
	(2, 'Bug', NULL, 'TSK_TYPE', NULL, NULL, 'BUG', 1, NULL, NULL, NULL),
	(3, 'To do', NULL, 'TSK_STATE', NULL, NULL, 'TO_DO', 0, NULL, NULL, NULL),
	(4, 'In progress', NULL, 'TSK_STATE', NULL, NULL, 'IN_PROGR', 1, NULL, NULL, NULL),
	(5, 'Done', NULL, 'TSK_STATE', NULL, NULL, 'DONE', 2, NULL, NULL, NULL),
	(6, 'Removed', NULL, 'TSK_STATE', NULL, NULL, 'REMOVED', 3, NULL, NULL, NULL),
	(7, 'Analyze', NULL, 'TSK_ACTIVITY', NULL, NULL, 'ANALYZE', 0, NULL, NULL, NULL),
	(8, 'Development', NULL, 'TSK_ACTIVITY', NULL, NULL, 'DEVELOP', 1, NULL, NULL, NULL),
	(9, 'Design', NULL, 'TSK_ACTIVITY', NULL, NULL, 'DESIGN', 2, NULL, NULL, NULL),
	(10, 'Deploy', NULL, 'TSK_ACTIVITY', NULL, NULL, 'DEPLOY', 3, NULL, NULL, NULL),
	(11, 'Documentation', NULL, 'TSK_ACTIVITY', NULL, NULL, 'DOC', 4, NULL, NULL, NULL),
	(12, 'Testing', NULL, 'TSK_ACTIVITY', NULL, NULL, 'TESTING', 4, NULL, NULL, NULL);

DELETE FROM `group`;
INSERT INTO `group` (`id`, `name`, `description`, `created`, `owner_id`, `deleted`) VALUES
	(1, 'Administrators', NULL, NOW(), 1, NULL),
	(2, 'Managers', NULL, NOW(), 1, NULL),
	(3, 'Architects', NULL, NOW(), 1, NULL),
	(4, 'Developers', NULL, NOW(), 1, NULL),
	(5, 'Designers', NULL, NOW(), 1, NULL),
	(6, 'Testers', NULL, NOW(), 1, NULL),
	(7, 'Support Team', NULL, NOW(), 1, NULL);


-- Dumping data for table wproject.user: ~1 rows (approximately)
DELETE FROM `user`;
INSERT INTO `user` (`id`, `name`, `email`, `login`, `word`, `expire`, `su`, `suspended`, `deleted`) VALUES
	(1, 'Administrator', '', 'admin', 'c4ca4238a0b923820dcc509a6f75849b', NULL, 1, NULL, NULL);

