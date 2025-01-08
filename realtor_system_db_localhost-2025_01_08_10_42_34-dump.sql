--
-- PostgreSQL database dump
--

-- Dumped from database version 17.0
-- Dumped by pg_dump version 17.0

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: public; Type: SCHEMA; Schema: -; Owner: pg_database_owner
--

CREATE SCHEMA public;


ALTER SCHEMA public OWNER TO pg_database_owner;

--
-- Name: SCHEMA public; Type: COMMENT; Schema: -; Owner: pg_database_owner
--

COMMENT ON SCHEMA public IS 'standard public schema';


SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO postgres;

--
-- Name: client; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.client (
    passport_id integer NOT NULL,
    last_name character varying(100),
    first_name character varying(100),
    middle_name character varying(100),
    birth_date date,
    gender_id character(1),
    user_id integer,
    phone character varying(100),
    email character varying(100),
    is_archive boolean DEFAULT false
);


ALTER TABLE public.client OWNER TO postgres;

--
-- Name: client_document; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.client_document (
    id integer NOT NULL,
    client_id integer,
    document_id integer
);


ALTER TABLE public.client_document OWNER TO postgres;

--
-- Name: client_document_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.client_document_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.client_document_id_seq OWNER TO postgres;

--
-- Name: client_document_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.client_document_id_seq OWNED BY public.client_document.id;


--
-- Name: contract; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.contract (
    id integer NOT NULL,
    date_create date,
    valid_until date,
    client_id integer,
    type_id integer,
    is_archive boolean
);


ALTER TABLE public.contract OWNER TO postgres;

--
-- Name: contract_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.contract_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.contract_id_seq OWNER TO postgres;

--
-- Name: contract_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.contract_id_seq OWNED BY public.contract.id;


--
-- Name: contract_type; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.contract_type (
    id integer NOT NULL,
    name character varying(100)
);


ALTER TABLE public.contract_type OWNER TO postgres;

--
-- Name: contract_type_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.contract_type_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.contract_type_id_seq OWNER TO postgres;

--
-- Name: contract_type_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.contract_type_id_seq OWNED BY public.contract_type.id;


--
-- Name: document; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.document (
    id integer NOT NULL,
    file_name character varying(300)
);


ALTER TABLE public.document OWNER TO postgres;

--
-- Name: document_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.document_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.document_id_seq OWNER TO postgres;

--
-- Name: document_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.document_id_seq OWNED BY public.document.id;


--
-- Name: gender; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.gender (
    id character(1) NOT NULL,
    name character varying(30)
);


ALTER TABLE public.gender OWNER TO postgres;

--
-- Name: material; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.material (
    id integer NOT NULL,
    name character varying(200)
);


ALTER TABLE public.material OWNER TO postgres;

--
-- Name: material_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.material_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.material_id_seq OWNER TO postgres;

--
-- Name: material_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.material_id_seq OWNED BY public.material.id;


--
-- Name: passport; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.passport (
    id integer NOT NULL,
    serial integer,
    number integer,
    issued_date date,
    issued_by character varying(200)
);


ALTER TABLE public.passport OWNER TO postgres;

--
-- Name: passport_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.passport_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.passport_id_seq OWNER TO postgres;

--
-- Name: passport_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.passport_id_seq OWNED BY public.passport.id;


--
-- Name: real_estate_object; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.real_estate_object (
    contract_id integer NOT NULL,
    address character varying(400),
    description character varying(1000),
    notes character varying(300),
    floor integer,
    floors_count integer,
    rooms_count integer,
    square numeric(10,2),
    price numeric(10,2),
    building_year integer,
    object_type_id integer,
    is_archive boolean DEFAULT false
);


ALTER TABLE public.real_estate_object OWNER TO postgres;

--
-- Name: real_estate_object_document; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.real_estate_object_document (
    id integer NOT NULL,
    real_estate_object_id integer,
    document_id integer
);


ALTER TABLE public.real_estate_object_document OWNER TO postgres;

--
-- Name: real_estate_object_document_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.real_estate_object_document_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.real_estate_object_document_id_seq OWNER TO postgres;

--
-- Name: real_estate_object_document_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.real_estate_object_document_id_seq OWNED BY public.real_estate_object_document.id;


--
-- Name: real_estate_object_photo; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.real_estate_object_photo (
    id integer NOT NULL,
    object_id integer,
    file_name character varying(200)
);


ALTER TABLE public.real_estate_object_photo OWNER TO postgres;

--
-- Name: real_estate_object_photo_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.real_estate_object_photo_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.real_estate_object_photo_id_seq OWNER TO postgres;

--
-- Name: real_estate_object_photo_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.real_estate_object_photo_id_seq OWNED BY public.real_estate_object_photo.id;


--
-- Name: real_estate_object_type; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.real_estate_object_type (
    id integer NOT NULL,
    name character varying(100)
);


ALTER TABLE public.real_estate_object_type OWNER TO postgres;

--
-- Name: real_estate_object_type_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.real_estate_object_type_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.real_estate_object_type_id_seq OWNER TO postgres;

--
-- Name: real_estate_object_type_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.real_estate_object_type_id_seq OWNED BY public.real_estate_object_type.id;


--
-- Name: user; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."user" (
    id integer NOT NULL,
    login character varying(100),
    password character varying(100),
    last_name character varying(100),
    first_name character varying(100),
    middle_name character varying(100)
);


ALTER TABLE public."user" OWNER TO postgres;

--
-- Name: user_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.user_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.user_id_seq OWNER TO postgres;

--
-- Name: user_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.user_id_seq OWNED BY public."user".id;


--
-- Name: client_document id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.client_document ALTER COLUMN id SET DEFAULT nextval('public.client_document_id_seq'::regclass);


--
-- Name: contract id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.contract ALTER COLUMN id SET DEFAULT nextval('public.contract_id_seq'::regclass);


--
-- Name: contract_type id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.contract_type ALTER COLUMN id SET DEFAULT nextval('public.contract_type_id_seq'::regclass);


--
-- Name: document id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.document ALTER COLUMN id SET DEFAULT nextval('public.document_id_seq'::regclass);


--
-- Name: material id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.material ALTER COLUMN id SET DEFAULT nextval('public.material_id_seq'::regclass);


--
-- Name: passport id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.passport ALTER COLUMN id SET DEFAULT nextval('public.passport_id_seq'::regclass);


--
-- Name: real_estate_object_document id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.real_estate_object_document ALTER COLUMN id SET DEFAULT nextval('public.real_estate_object_document_id_seq'::regclass);


--
-- Name: real_estate_object_photo id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.real_estate_object_photo ALTER COLUMN id SET DEFAULT nextval('public.real_estate_object_photo_id_seq'::regclass);


--
-- Name: real_estate_object_type id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.real_estate_object_type ALTER COLUMN id SET DEFAULT nextval('public.real_estate_object_type_id_seq'::regclass);


--
-- Name: user id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."user" ALTER COLUMN id SET DEFAULT nextval('public.user_id_seq'::regclass);


--
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."__EFMigrationsHistory" VALUES ('20250105121013_Add_Columns_In_Client', '8.0.11');
INSERT INTO public."__EFMigrationsHistory" VALUES ('20250105121536_Drop_Columns_In_Client', '8.0.11');
INSERT INTO public."__EFMigrationsHistory" VALUES ('20250105121841_Add_Columns_In_Client', '8.0.11');
INSERT INTO public."__EFMigrationsHistory" VALUES ('20250105122103_Add_Columns_In_Client', '8.0.11');


--
-- Data for Name: client; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.client VALUES (8, 'Федосеев', 'Андрей', 'Андреевич', '1993-12-18', 'M', 1, '66564343', 'tyubjgjh@mail.ru', false);
INSERT INTO public.client VALUES (1, 'Романов', 'Роман', 'Романович', '1990-05-15', 'M', 1, '89254771221', 'hgjnnbsdt@mail.ru', false);
INSERT INTO public.client VALUES (14, 'asdf', 'asdf', 'sdf', '2025-01-04', 'M', 1, '233', NULL, true);
INSERT INTO public.client VALUES (10, 'Белов', 'Валентина', 'Валентиновна', '1989-02-28', 'F', 1, '234234', 'fgjcvbn@mail.ru', true);
INSERT INTO public.client VALUES (2, 'Волков', 'Евгений', 'Евгеньевич', '1985-06-20', 'M', 1, '3452345', 'asdfkjh@mail.ru', false);
INSERT INTO public.client VALUES (4, 'Григорьев', 'Анастасия', 'Анастасиевна', '1988-08-25', 'F', 1, '45634573', 'fghfgh@mail.ru', false);
INSERT INTO public.client VALUES (6, 'Чернов', 'Дмитрий', 'Дмитриевич', '1980-10-05', 'M', 1, '523454', 'gtyueee@mail.ru', false);
INSERT INTO public.client VALUES (3, 'Соловьев', 'Виктория', 'Викторовна', '1992-07-10', 'F', 1, '3454565', 'bnvb@mail.ru', false);
INSERT INTO public.client VALUES (7, 'Лебедев', 'Сергей', 'Сергеевич', '1987-11-12', 'M', 1, '23546543', 'ery46r65@mail.ru', false);
INSERT INTO public.client VALUES (9, 'Морозова', 'Артем', 'Артемович', '1991-01-22', 'M', 1, '7344345346', 'jjhgfd8765@mail.ru', false);
INSERT INTO public.client VALUES (5, 'Ковалев', 'Николай', 'Николаевич', '1995-09-30', 'M', 1, '36345634', 'g5684dfvv@mail.ru', false);


--
-- Data for Name: client_document; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Data for Name: contract; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.contract VALUES (1, '2025-01-07', '2025-01-23', 1, 1, true);
INSERT INTO public.contract VALUES (2, '2025-01-08', '2025-01-24', 2, 2, true);
INSERT INTO public.contract VALUES (3, '2025-01-06', '2025-01-20', 1, 1, true);
INSERT INTO public.contract VALUES (4, '2025-01-07', '2025-01-07', 10, 1, true);


--
-- Data for Name: contract_type; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.contract_type VALUES (1, 'Контракт на покупку');
INSERT INTO public.contract_type VALUES (2, 'Контракт на продажу');


--
-- Data for Name: document; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Data for Name: gender; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.gender VALUES ('M', 'Мужской');
INSERT INTO public.gender VALUES ('F', 'Женский');


--
-- Data for Name: material; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Data for Name: passport; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.passport VALUES (2, 2345, 678901, '2021-02-02', 'УФМС России');
INSERT INTO public.passport VALUES (3, 3456, 789012, '2022-03-03', 'УФМС России');
INSERT INTO public.passport VALUES (4, 4567, 890123, '2023-04-04', 'УФМС России');
INSERT INTO public.passport VALUES (5, 5678, 901234, '2024-05-05', 'УФМС России');
INSERT INTO public.passport VALUES (6, 6789, 12345, '2025-06-06', 'УФМС России');
INSERT INTO public.passport VALUES (7, 7890, 123456, '2026-07-07', 'УФМС России');
INSERT INTO public.passport VALUES (8, 8901, 234567, '2027-08-08', 'УФМС России');
INSERT INTO public.passport VALUES (9, 9012, 345678, '2028-09-09', 'УФМС России');
INSERT INTO public.passport VALUES (10, 123, 456789, '2029-10-10', 'УФМС России');
INSERT INTO public.passport VALUES (1, 1234, 567890, '2020-01-01', 'УФМС России');
INSERT INTO public.passport VALUES (13, 3132, 313132, '2025-01-08', 'h');
INSERT INTO public.passport VALUES (14, 2341, 234123, '2025-01-23', 'asdfasd');


--
-- Data for Name: real_estate_object; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.real_estate_object VALUES (3, 'Серпухов ул Осенняя 7', 'дом', 'дом', 3, 9, 3, 220.00, 8500000.00, 1999, 2, false);
INSERT INTO public.real_estate_object VALUES (1, 'Серпухов ул Ворошилова 12а', 'дом', 'дом', 1, 10, 3, 100.00, 4500000.00, 2000, 2, false);
INSERT INTO public.real_estate_object VALUES (2, 'Серпухов ул Пушкина 17б', 'дом', 'дом', 2, 5, 2, 100.00, 2700000.00, 2000, 2, false);


--
-- Data for Name: real_estate_object_document; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Data for Name: real_estate_object_photo; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Data for Name: real_estate_object_type; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.real_estate_object_type VALUES (1, 'Дом');
INSERT INTO public.real_estate_object_type VALUES (2, 'Квартира');


--
-- Data for Name: user; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."user" VALUES (2, 'user2', 'pass5678', 'Петров', 'Петр', 'Петрович');
INSERT INTO public."user" VALUES (3, 'user3', 'pass91011', 'Сидоров', 'Сидор', 'Сидорович');
INSERT INTO public."user" VALUES (4, 'user4', 'passabcd', 'Смирнов', 'Алексей', 'Алексеевич');
INSERT INTO public."user" VALUES (5, 'user5', 'passefgh', 'Кузнецов', 'Николай', 'Николаевич');
INSERT INTO public."user" VALUES (6, 'user6', 'passijkl', 'Попов', 'Дмитрий', 'Дмитриевич');
INSERT INTO public."user" VALUES (7, 'user7', 'passmnop', 'Васильев', 'Сергей', 'Сергеевич');
INSERT INTO public."user" VALUES (8, 'user8', 'passqrst', 'Федоров', 'Андрей', 'Андреевич');
INSERT INTO public."user" VALUES (9, 'user9', 'passuvwx', 'Морозов', 'Артем', 'Артемович');
INSERT INTO public."user" VALUES (10, 'user10', 'passyz12', 'Лебедев', 'Валентин', 'Валентинович');
INSERT INTO public."user" VALUES (1, '1', '1', 'Иванов', 'Иван', 'Иванович');
INSERT INTO public."user" VALUES (11, 'alena', 'pass', 'Богданович', 'Алена', 'Алексеевна');


--
-- Name: client_document_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.client_document_id_seq', 2, true);


--
-- Name: contract_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.contract_id_seq', 4, true);


--
-- Name: contract_type_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.contract_type_id_seq', 2, true);


--
-- Name: document_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.document_id_seq', 2, true);


--
-- Name: material_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.material_id_seq', 1, false);


--
-- Name: passport_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.passport_id_seq', 14, true);


--
-- Name: real_estate_object_document_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.real_estate_object_document_id_seq', 1, false);


--
-- Name: real_estate_object_photo_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.real_estate_object_photo_id_seq', 1, false);


--
-- Name: real_estate_object_type_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.real_estate_object_type_id_seq', 2, true);


--
-- Name: user_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.user_id_seq', 11, true);


--
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- Name: client_document client_document_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.client_document
    ADD CONSTRAINT client_document_pkey PRIMARY KEY (id);


--
-- Name: client client_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.client
    ADD CONSTRAINT client_pkey PRIMARY KEY (passport_id);


--
-- Name: contract contract_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.contract
    ADD CONSTRAINT contract_pkey PRIMARY KEY (id);


--
-- Name: contract_type contract_type_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.contract_type
    ADD CONSTRAINT contract_type_pkey PRIMARY KEY (id);


--
-- Name: document document_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.document
    ADD CONSTRAINT document_pkey PRIMARY KEY (id);


--
-- Name: gender gender_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.gender
    ADD CONSTRAINT gender_pkey PRIMARY KEY (id);


--
-- Name: material material_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.material
    ADD CONSTRAINT material_pkey PRIMARY KEY (id);


--
-- Name: passport passport_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.passport
    ADD CONSTRAINT passport_pkey PRIMARY KEY (id);


--
-- Name: real_estate_object_document real_estate_object_document_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.real_estate_object_document
    ADD CONSTRAINT real_estate_object_document_pkey PRIMARY KEY (id);


--
-- Name: real_estate_object_photo real_estate_object_photo_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.real_estate_object_photo
    ADD CONSTRAINT real_estate_object_photo_pkey PRIMARY KEY (id);


--
-- Name: real_estate_object real_estate_object_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.real_estate_object
    ADD CONSTRAINT real_estate_object_pkey PRIMARY KEY (contract_id);


--
-- Name: real_estate_object_type real_estate_object_type_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.real_estate_object_type
    ADD CONSTRAINT real_estate_object_type_pkey PRIMARY KEY (id);


--
-- Name: user user_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."user"
    ADD CONSTRAINT user_pkey PRIMARY KEY (id);


--
-- Name: client client___fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.client
    ADD CONSTRAINT client___fk FOREIGN KEY (user_id) REFERENCES public."user"(id);


--
-- Name: client_document client_document_client_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.client_document
    ADD CONSTRAINT client_document_client_id_fkey FOREIGN KEY (client_id) REFERENCES public.client(passport_id);


--
-- Name: client_document client_document_document_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.client_document
    ADD CONSTRAINT client_document_document_id_fkey FOREIGN KEY (document_id) REFERENCES public.document(id) ON DELETE CASCADE;


--
-- Name: client client_gender_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.client
    ADD CONSTRAINT client_gender_id_fkey FOREIGN KEY (gender_id) REFERENCES public.gender(id);


--
-- Name: client client_passport_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.client
    ADD CONSTRAINT client_passport_id_fkey FOREIGN KEY (passport_id) REFERENCES public.passport(id);


--
-- Name: contract contract_client_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.contract
    ADD CONSTRAINT contract_client_id_fkey FOREIGN KEY (client_id) REFERENCES public.client(passport_id);


--
-- Name: contract contract_type_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.contract
    ADD CONSTRAINT contract_type_id_fkey FOREIGN KEY (type_id) REFERENCES public.contract_type(id);


--
-- Name: real_estate_object real_estate_object_contract_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.real_estate_object
    ADD CONSTRAINT real_estate_object_contract_id_fkey FOREIGN KEY (contract_id) REFERENCES public.contract(id);


--
-- Name: real_estate_object_document real_estate_object_document_document_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.real_estate_object_document
    ADD CONSTRAINT real_estate_object_document_document_id_fkey FOREIGN KEY (document_id) REFERENCES public.document(id) ON DELETE CASCADE;


--
-- Name: real_estate_object_document real_estate_object_document_real_estate_object_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.real_estate_object_document
    ADD CONSTRAINT real_estate_object_document_real_estate_object_id_fkey FOREIGN KEY (real_estate_object_id) REFERENCES public.real_estate_object(contract_id);


--
-- Name: real_estate_object real_estate_object_object_type_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.real_estate_object
    ADD CONSTRAINT real_estate_object_object_type_fkey FOREIGN KEY (object_type_id) REFERENCES public.real_estate_object_type(id);


--
-- Name: real_estate_object_photo real_estate_object_photo_object_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.real_estate_object_photo
    ADD CONSTRAINT real_estate_object_photo_object_id_fkey FOREIGN KEY (object_id) REFERENCES public.real_estate_object(contract_id);


--
-- PostgreSQL database dump complete
--

