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

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: client; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.client (
    passport_id integer NOT NULL,
    last_name character varying(100),
    first_name character varying(100),
    middle_name character varying(100),
    birth_date date,
    gender_id character(1)
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
    is_archive bit(1),
    employee_id integer
);


ALTER TABLE public.contract OWNER TO postgres;

--
-- Name: contract_document; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.contract_document (
    id integer NOT NULL,
    contract_id integer,
    document_id integer
);


ALTER TABLE public.contract_document OWNER TO postgres;

--
-- Name: contract_document_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.contract_document_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.contract_document_id_seq OWNER TO postgres;

--
-- Name: contract_document_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.contract_document_id_seq OWNED BY public.contract_document.id;


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
    description character varying(300),
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
    passport_serial integer,
    passport_number integer,
    passport_issued_date date,
    passport_issued_by character varying(200),
    passport_valid_until date
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
    is_archive bit(1),
    object_type integer
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
-- Name: contract_document id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.contract_document ALTER COLUMN id SET DEFAULT nextval('public.contract_document_id_seq'::regclass);


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
-- Data for Name: client; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.client (passport_id, last_name, first_name, middle_name, birth_date, gender_id) FROM stdin;
\.


--
-- Data for Name: client_document; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.client_document (id, client_id, document_id) FROM stdin;
\.


--
-- Data for Name: contract; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.contract (id, date_create, valid_until, client_id, type_id, is_archive, employee_id) FROM stdin;
\.


--
-- Data for Name: contract_document; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.contract_document (id, contract_id, document_id) FROM stdin;
\.


--
-- Data for Name: contract_type; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.contract_type (id, name) FROM stdin;
\.


--
-- Data for Name: document; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.document (id, description, file_name) FROM stdin;
\.


--
-- Data for Name: gender; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.gender (id, name) FROM stdin;
\.


--
-- Data for Name: material; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.material (id, name) FROM stdin;
\.


--
-- Data for Name: passport; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.passport (id, passport_serial, passport_number, passport_issued_date, passport_issued_by, passport_valid_until) FROM stdin;
\.


--
-- Data for Name: real_estate_object; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.real_estate_object (contract_id, address, description, notes, floor, floors_count, rooms_count, square, price, building_year, is_archive, object_type) FROM stdin;
\.


--
-- Data for Name: real_estate_object_document; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.real_estate_object_document (id, real_estate_object_id, document_id) FROM stdin;
\.


--
-- Data for Name: real_estate_object_photo; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.real_estate_object_photo (id, object_id, file_name) FROM stdin;
\.


--
-- Data for Name: real_estate_object_type; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.real_estate_object_type (id, name) FROM stdin;
\.


--
-- Data for Name: user; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."user" (id, login, password, last_name, first_name, middle_name) FROM stdin;
\.


--
-- Name: client_document_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.client_document_id_seq', 1, false);


--
-- Name: contract_document_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.contract_document_id_seq', 1, false);


--
-- Name: contract_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.contract_id_seq', 1, false);


--
-- Name: contract_type_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.contract_type_id_seq', 1, false);


--
-- Name: document_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.document_id_seq', 1, false);


--
-- Name: material_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.material_id_seq', 1, false);


--
-- Name: passport_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.passport_id_seq', 1, false);


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

SELECT pg_catalog.setval('public.real_estate_object_type_id_seq', 1, false);


--
-- Name: user_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.user_id_seq', 1, false);


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
-- Name: contract_document contract_document_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.contract_document
    ADD CONSTRAINT contract_document_pkey PRIMARY KEY (id);


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
-- Name: client_document client_document_client_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.client_document
    ADD CONSTRAINT client_document_client_id_fkey FOREIGN KEY (client_id) REFERENCES public.client(passport_id);


--
-- Name: client_document client_document_document_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.client_document
    ADD CONSTRAINT client_document_document_id_fkey FOREIGN KEY (document_id) REFERENCES public.document(id);


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
-- Name: contract_document contract_document_contract_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.contract_document
    ADD CONSTRAINT contract_document_contract_id_fkey FOREIGN KEY (contract_id) REFERENCES public.contract(id);


--
-- Name: contract_document contract_document_document_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.contract_document
    ADD CONSTRAINT contract_document_document_id_fkey FOREIGN KEY (document_id) REFERENCES public.document(id);


--
-- Name: contract contract_employee_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.contract
    ADD CONSTRAINT contract_employee_id_fkey FOREIGN KEY (employee_id) REFERENCES public."user"(id);


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
    ADD CONSTRAINT real_estate_object_document_document_id_fkey FOREIGN KEY (document_id) REFERENCES public.document(id);


--
-- Name: real_estate_object_document real_estate_object_document_real_estate_object_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.real_estate_object_document
    ADD CONSTRAINT real_estate_object_document_real_estate_object_id_fkey FOREIGN KEY (real_estate_object_id) REFERENCES public.real_estate_object(contract_id);


--
-- Name: real_estate_object real_estate_object_object_type_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.real_estate_object
    ADD CONSTRAINT real_estate_object_object_type_fkey FOREIGN KEY (object_type) REFERENCES public.real_estate_object_type(id);


--
-- Name: real_estate_object_photo real_estate_object_photo_object_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.real_estate_object_photo
    ADD CONSTRAINT real_estate_object_photo_object_id_fkey FOREIGN KEY (object_id) REFERENCES public.real_estate_object(contract_id);


--
-- PostgreSQL database dump complete
--

