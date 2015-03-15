# XRMVersionControl
test task for XRM

<a href="http://xrm.ru/job/test_task/">Тестовое задание №2 для "Экстрим"</a>

Допущения и ограничения:

<ol>
<li>Аплоадятся только *.dll сборки</li>
<li>Сборка валидируется только на тип и на непустоту</li>
<li>В решении не добавлено логирование</li>
<li>не добавлен UnitOfWork из-за простоты данных</li>
<li>не добавлены транзакции - также из-за простоты логики</li>
<li>не добавлены тесты</li>
<li>не добавлена обработка ошибок</li>
<li>UI примитивный</li>
</ol>
Предложенное решение, конечно, слишком сложное в архитектурном плане для такой небольшой задачи, но это типичная структура проектов, надо которыми я работала, и я хотела это показать.

Как работать с решением:
решение представляет собой веб-приложение, в котором можно загрузить сборку, и посмотреть историю ее изменений (страница истории доступна только с загрузки).
Можно использовать сборку проекта "TestLib" - в ней содержатся тестовые данные. 

Окно загрузки:
http://awesomescreenshot.com/0ca4mmxp7a
Окно страницы истории изменений:
http://awesomescreenshot.com/0714mmy965


